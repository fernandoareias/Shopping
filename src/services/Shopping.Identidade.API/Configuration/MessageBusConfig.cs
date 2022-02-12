using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Identidade.API.Configurations.Extensions;
using Shopping.Identidade.API.Extensions;

namespace Shopping.Identidade.API.Configurations
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services)
        {
            services.AddMessageBus();
        }
    }
}
