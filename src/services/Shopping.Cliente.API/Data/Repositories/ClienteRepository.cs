using Microsoft.EntityFrameworkCore;
using Shopping.Cliente.API.Models.Interfaces;
using Shopping.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public async void Adicionar(Models.Cliente entity)
        {
            await _context.Cliente.AddAsync(entity);
        }

        public void Atualizar(Models.Cliente entity)
        {
            _context.Cliente.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Models.Cliente> ObterPorCpf(string cpf)
        {
            return await _context.Cliente.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<Models.Cliente> ObterPorId(Guid id)
        {
            return await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Models.Cliente>> ObterTodosAsync()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }
    }
}
