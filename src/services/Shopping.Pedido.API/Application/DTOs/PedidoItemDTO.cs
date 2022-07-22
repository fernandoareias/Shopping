using Shopping.Pedido.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.DTOs
{
    public class PedidoItemDTO
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string ProdutoImagem { get; set; }


        public PedidoItemDTO(PedidoItem pedidoItem)
        {
            this.PedidoId = pedidoItem.PedidoId;
            this.ProdutoId = pedidoItem.ProdutoId;
            this.ProdutoNome = pedidoItem.ProdutoNome;
            this.Quantidade = pedidoItem.Quantidade;
            this.ValorUnitario = pedidoItem.ValorUnitario;
            this.ProdutoImagem = pedidoItem.ProdutoImagem;
        }

        public PedidoItem ParaPedidoItem()
            => new PedidoItem(this.PedidoId, this.ProdutoNome, this.Quantidade, this.ValorUnitario, this.ProdutoId, this.ProdutoImagem);

    }
}
