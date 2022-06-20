using Shopping.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Models.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterPorCpf(string cpf);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente> ObterPorId(Guid id);
        void Adicionar(Cliente entity);
        void Atualizar(Cliente entity);
    }
}
