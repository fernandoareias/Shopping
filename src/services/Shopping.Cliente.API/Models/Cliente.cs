using Shopping.Core.DomainObjects;
using Shopping.Core.Interfaces;
using Shopping.Core.DomainObjects.ValueObjects;
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

        public Cliente(string nome, string email, string cpf, bool excluido = false, Endereco endereco = null)
        {
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Excluido = excluido;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
