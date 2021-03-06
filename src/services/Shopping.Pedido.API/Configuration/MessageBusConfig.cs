using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping.MessageBus;

namespace Shopping.Pedido.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection RegistraMessageBus(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMessageBus(configuration.GetSection("MessageBus").Value);
            return service;
        }
    }
}
