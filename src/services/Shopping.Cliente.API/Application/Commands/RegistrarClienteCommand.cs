using Shopping.Core.Messages;
using System;

namespace Shopping.Cliente.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            AggregateId = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
