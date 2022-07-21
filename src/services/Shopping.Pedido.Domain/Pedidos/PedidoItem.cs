using Shopping.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Domain.Pedidos
{
    public class PedidoItem : Entity
    {
        protected PedidoItem()
        {

        }

        public PedidoItem(Guid pedidoId, string produtoNome, int quantidade, decimal valorUnitario, Guid produtoId, string produtoImagem = null)
        {
            PedidoId = pedidoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ProdutoImagem = produtoImagem;
            ProdutoId = produtoId;
        }

        public Guid PedidoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string ProdutoImagem { get; set; }


        public Guid ProdutoId { get; private set; }
        public Pedido Pedido { get; set; }

        internal decimal CalcularValor() => Quantidade * ValorUnitario;

    }
}
