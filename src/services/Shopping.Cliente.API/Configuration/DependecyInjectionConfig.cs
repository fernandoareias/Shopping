using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Cliente.API.Application.Commands;
using Shopping.Cliente.API.Application.Commands.Handles;
using Shopping.Cliente.API.Data;
using Shopping.Core.Data;
using Shopping.Core.Mediator;

namespace Shopping.Cliente.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection RegistraServices(this IServiceCollection service)
        {
            service.AddScoped<IMediatRHandler, MediatRHandler>();
            service.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            service.AddScoped<IUnitOfWork, ClientesContext>();

            return service;
        }
    }
}
