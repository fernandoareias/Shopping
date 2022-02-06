using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Cliente.API.Application.Commands;
using Shopping.Cliente.API.Application.Events;
using Shopping.Cliente.API.Application.Handler;
using Shopping.Cliente.API.Application.Identity;
using Shopping.Cliente.API.Data;
using Shopping.Cliente.API.Data.Repository;
using Shopping.Cliente.API.Models.Interfaces;
using Shopping.Cliente.API.Shared.Mediator;

namespace Shopping.Cliente.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarEnderecoCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClienteContext>();
        }
    }
}
