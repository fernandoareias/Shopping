using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Core.Data;
using Shopping.Core.Mediator;

namespace Shopping.Carrinho.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection RegistraServices(this IServiceCollection service)
        {
            //service.AddScoped<IUnitOfWork, ClientesContext>();

            return service;
        }
    }
}
