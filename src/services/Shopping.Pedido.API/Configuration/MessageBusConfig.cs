using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shopping.Pedido.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection RegistraMessageBus(this IServiceCollection service, IConfiguration configuration)
        {
           
            return service;
        }
    }
}
