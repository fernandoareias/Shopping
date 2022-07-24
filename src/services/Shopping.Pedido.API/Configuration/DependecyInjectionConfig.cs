using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Shopping.Core.Data;
using Shopping.Core.Mediator;
using Shopping.Pedido.API.Application.Commands;
using Shopping.Pedido.API.Application.Events;
using Shopping.Pedido.API.Application.Queries;
using Shopping.Pedido.Domain.Vouchers.Interfaces;
using Shopping.Pedido.Infra.Data;
using Shopping.Pedido.Infra.Data.Repositories;
using Shopping.WebAPI.Core.Usuario;

namespace Shopping.Pedido.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection RegistraServices(this IServiceCollection service)
        {

            // API
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<IAspNetUser, AspNetUser>();

            // App
            service.AddScoped<IMediatorHandler, MediatRHandler>();
            service.AddScoped<IVoucherQueries, VoucherQueries>();
         
            // Data
            service.AddScoped<PedidoContext>();
            service.AddScoped<IVoucherRepository, VoucherRepository>();


            service.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            service.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            return service;
        }
    }
}
