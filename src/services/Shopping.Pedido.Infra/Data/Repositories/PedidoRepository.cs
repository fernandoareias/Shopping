using Microsoft.EntityFrameworkCore;
using Shopping.Core.Data;
using Shopping.Pedido.Domain.Pedidos;
using Shopping.Pedido.Domain.Pedidos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Pedido.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;

        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Domain.Pedidos.Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Atualizar(Domain.Pedidos.Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<PedidoItem> ObterItemPorId(Guid id)
        {
            return await _context.PedidoItems.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PedidoItem> ObterItemPorPedidoId(Guid pedidoId, Guid produtoId)
        {
            return await _context.PedidoItems.FirstOrDefaultAsync(p => p.Id == pedidoId && p.ProdutoId == produtoId);
        }

        public async Task<IEnumerable<Domain.Pedidos.Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            return await _context
                .Pedidos
                .Include(c => c.PedidoItems)
                .AsNoTracking()
                .Where(q => q.ClienteId == clienteId)
                .ToListAsync();
        }

        public Task<Domain.Pedidos.Pedido> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public DbConnection ObterConexao()
            => _context.Database.GetDbConnection();
        
    }
}
