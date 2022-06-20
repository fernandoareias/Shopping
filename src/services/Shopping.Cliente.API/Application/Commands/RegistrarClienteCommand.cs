using Shopping.Core.Messages;
using System;

namespace Shopping.Cliente.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public RegistrarClienteCommand(string nome, string email, string cpf)
        {
            
            AggregateId = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

    }
}
