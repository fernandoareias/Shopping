using Microsoft.Extensions.DependencyInjection;
using Shopping.Cliente.API.Shared.Messages.Bus;
using System;

namespace Shopping.Cliente.API.Configurations.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
