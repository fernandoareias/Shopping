using FluentValidation.Results;
using MediatR;
using Shopping.Cliente.API.Models;
using Shopping.Cliente.API.Models.Interfaces;
using Shopping.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Application.Commands.Handles
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var clienteExiste = await _clienteRepository.ObterPorCpf(message.Cpf);
            if(clienteExiste != null)
            {
                AdicionarErro("O CPF informado já está cadastrado.");
                return ValidationResult;
            }

            var cliente = new Shopping.Cliente.API.Models.Cliente(message.Nome, message.Email, message.Cpf);

            _clienteRepository.Adicionar(cliente);

            return await PersistirDados(_clienteRepository.UnitOfWork);
        }
    }
}
