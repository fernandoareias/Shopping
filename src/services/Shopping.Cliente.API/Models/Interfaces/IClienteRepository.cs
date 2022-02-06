using Shopping.Cliente.API.Models.VOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Models.Interfaces
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);

        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);

        void AdicionarEndereco(Endereco endereco);
        Task<Endereco> ObterEnderecoPorId(Guid id);
    }
}
