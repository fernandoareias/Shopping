using System;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Identidade.API.Shared.Messages.Bus;

namespace Shopping.Identidade.API.Extensions
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
