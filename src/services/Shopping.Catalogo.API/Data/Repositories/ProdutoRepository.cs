using Microsoft.EntityFrameworkCore;
using Shopping.Catalogo.API.Models;
using Shopping.Catalogo.API.Models.Interfaces;
using Shopping.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Catalogo.API.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;
        private readonly IUnitOfWork _uow;

        public ProdutoRepository(CatalogoContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }
        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _uow.Commit();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _uow.Commit();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
