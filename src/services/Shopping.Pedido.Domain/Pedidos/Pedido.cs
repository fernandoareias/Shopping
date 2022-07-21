using Shopping.Core.DomainObjects;
using Shopping.Core.Interfaces;
using Shopping.Pedido.Domain.Pedidos.Enums;
using Shopping.Pedido.Domain.Pedidos.ValueObjects;
using Shopping.Pedido.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Domain.Pedidos
{
    public class Pedido : Entity, IAggregateRoot
    {
        protected Pedido() {}

        public Pedido(Guid clienteId, decimal valorTotal, List<PedidoItem> items, 
            bool voucherUtilizado = false, decimal desconto = 0, Guid? voucherId = null)
        {
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            _pedidoItems = items;

            Desconto = desconto;
            VoucherUtilizado = voucherUtilizado;
            VoucherId = voucherId;
        }

        public int Codigo { get; private set; }
        public Guid ClienteId { get; set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;


        public Endereco Endereco { get; private set; }

        // EF
        public Voucher Voucher { get; private set; }


        public void AutorizarPedido() => PedidoStatus = PedidoStatus.Autorizado;

        public void AtribuirVoucher(Voucher voucher)
        {
            VoucherUtilizado = true;
            VoucherId = voucher.Id;
            Voucher = voucher;
        }

        private void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Voucher.TipoDesconto == TipoDescontoVoucher.Procentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

    }
}
