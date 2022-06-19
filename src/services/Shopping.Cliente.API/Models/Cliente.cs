using Shopping.Core.DomainObjects;
using Shopping.Core.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        protected Cliente()
        {

        }

        public Cliente(string nome, string email, string cpf, bool excluido, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Excluido = excluido;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
