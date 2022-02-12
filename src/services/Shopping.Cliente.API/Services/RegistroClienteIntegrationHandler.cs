using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.Cliente.API.Application.Commands;
using Shopping.Cliente.API.Application.Events;
using Shopping.Cliente.API.Shared.Integration;
using Shopping.Cliente.API.Shared.Mediator;
using Shopping.Cliente.API.Shared.Messages.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Services
{
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public RegistroClienteIntegrationHandler(
                            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
           
        }

 
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

         
            return Task.CompletedTask;
        }

    }
}
