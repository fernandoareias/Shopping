using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Cliente.API.Application.Commands;
using Shopping.Cliente.API.Application.Commands.Handles;
using Shopping.Cliente.API.Application.Events;
using Shopping.Cliente.API.Application.Events.Handles;
using Shopping.Cliente.API.Data;
using Shopping.Cliente.API.Services;
using Shopping.Core.Data;
using Shopping.Core.Mediator;

namespace Shopping.Cliente.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection RegistraServices(this IServiceCollection service)
        {
            service.AddScoped<IMediatorHandler, MediatRHandler>();
            service.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            service.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandlers>();
            service.AddScoped<IUnitOfWork, ClientesContext>();

            service.AddHostedService<RegistroClienteIntegrationHandler>();
            return service;
        }
    }
}
