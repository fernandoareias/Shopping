using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Carrinho.API.Services;
using Shopping.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Carrinho.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection RegistraMessageBus(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMessageBus(configuration.GetSection("MessageBus").Value)
                .AddHostedService<CarrinhoIntegrationHandler>();

            return service;
        }
    }
}
