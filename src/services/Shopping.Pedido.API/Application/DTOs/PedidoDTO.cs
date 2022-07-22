using Shopping.Pedido.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.DTOs
{
    public class PedidoDTO
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public bool VoucherUtilizado { get; set; }
        public List<PedidoItemDTO> PedidoItems { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public PedidoDTO(Pedido.Domain.Pedidos.Pedido pedido)
        {
            this.Id = pedido.Id;
            this.Codigo = pedido.Codigo;
            this.Status = (int)pedido.PedidoStatus;
            this.Data = pedido.DataCadastro;
            this.ValorTotal = pedido.ValorTotal;
            this.Desconto = pedido.Desconto;
            this.VoucherUtilizado = pedido.VoucherUtilizado;
            this.PedidoItems = pedido.PedidoItems.Select(e => new PedidoItemDTO(e)).ToList();
            this.Endereco = new EnderecoDTO(pedido.Endereco);
        }
    }
}
