using FluentValidation.Results;
using MediatR;
using Shopping.Core.Messages;
using Shopping.Pedido.API.Application.Events;
using Shopping.Pedido.Domain.Pedidos.Interfaces;
using Shopping.Pedido.Domain.Pedidos.ValueObjects;
using Shopping.Pedido.Domain.Vouchers.Interfaces;
using Shopping.Pedido.Domain.Vouchers.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler, IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {

        private readonly IVoucherRepository _voucherRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IVoucherRepository voucherRepository, IPedidoRepository pedidoRepository)
        {
            _voucherRepository = voucherRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var pedido = MapearPedido(request);

            if (!await AplicarVoucher(request, pedido)) 
                return ValidationResult;

            if(!ProcessarPagamento(pedido))
                return ValidationResult;

            pedido.AutorizarPedido();

            pedido.AdicionarEvento(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

            _pedidoRepository.Adicionar(pedido);

            return await PersistirDados(_pedidoRepository.UnitOfWork);

        }


        private Pedido.Domain.Pedidos.Pedido MapearPedido(AdicionarPedidoCommand command)
        {
            var endereco = new Endereco(command.Endereco.Logradouro, command.Endereco.Numero, command.Endereco.Complemento, command.Endereco.Bairro, command.Endereco.Cep, command.Endereco.Cidade, command.Endereco.Estado);

            var pedido = new Pedido.Domain.Pedidos.Pedido(command.ClienteId, command.ValorTotal, command.PedidoItems.Select(c => c.ParaPedidoItem()).ToList(), command.VoucherUtilizado, command.Desconto);

            pedido.AtribuirEndereco(endereco);

            return pedido;
        }
    
        private bool ValidarPedido(Pedido.Domain.Pedidos.Pedido pedido)
        {
            var pedidoValorOriginal = pedido.ValorTotal;
            var pedidoDesconto = pedido.Desconto;

            pedido.CalcularPedido();

            if(pedido.ValorTotal != pedidoValorOriginal)
            {
                AdicionarErro("O valor total do pedido não confere com o cálculo do pedido");
                return false;
            }

            if(pedido.Desconto != pedidoDesconto)
            {
                AdicionarErro("O valor total não confere com o cálculo do pedido");
                return false;
            }

            return true;
        }
        private async Task<bool> AplicarVoucher(AdicionarPedidoCommand message, Pedido.Domain.Pedidos.Pedido pedido)
        {
            if (!message.VoucherUtilizado)
                return true;

            var voucher = await _voucherRepository.ObterVoucherPorCodigoAsync(message.VoucherCodigo);

            if(voucher == null)
            {
                AdicionarErro("O voucher informado não existe!");
                return false;
            }

            var voucherValidation = new VoucherValidation().Validate(voucher);

            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ToList().ForEach(m => AdicionarErro(m.ErrorMessage));
                return false;
            }

            pedido.AtribuirVoucher(voucher);
            voucher.DebitarQuantidade();

            _voucherRepository.Atualizar(voucher);

            return true;

        }
  
        public bool ProcessarPagamento(Pedido.Domain.Pedidos.Pedido pedido)
        {
            return true;
        }
    }
}
