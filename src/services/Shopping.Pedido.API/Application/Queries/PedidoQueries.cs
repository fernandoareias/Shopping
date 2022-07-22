using Shopping.Pedido.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.Queries
{
    public interface IPedidoQueries 
    {
        Task<PedidoDTO> ObterUltimoPedido(Guid clienteId);
        Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clienteId);
    }

    public class PedidoQueries : IPedidoQueries
    {
        public Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDTO> ObterUltimoPedido(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
