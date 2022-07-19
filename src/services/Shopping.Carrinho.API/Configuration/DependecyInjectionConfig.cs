using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Bff.Compras.Extensions;
using Shopping.Core.Data;
using Shopping.Core.Mediator;
using Shopping.WebAPI.Core.Usuario;

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
