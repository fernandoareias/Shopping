using Shopping.Cliente.API.Models.VOs;
using Shopping.Cliente.API.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Models.Interfaces
{
    public interface IClienteRepository : IRepository<Clientes>
    {
        void Adicionar(Clientes cliente);

        Task<IEnumerable<Clientes>> ObterTodos();
        Task<Clientes> ObterPorCpf(string cpf);

        void AdicionarEndereco(Endereco endereco);
        Task<Endereco> ObterEnderecoPorId(Guid id);
    }
}
