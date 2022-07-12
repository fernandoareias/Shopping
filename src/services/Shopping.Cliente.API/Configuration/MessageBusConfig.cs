using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Cliente.API.Services;
using Shopping.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection RegistraMessageBus(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMessageBus(configuration.GetSection("MessageQueueConnection")?["MessageBus"])
                .AddHostedService<RegistroClienteIntegrationHandler>();

            return service;
        }
    }
}
