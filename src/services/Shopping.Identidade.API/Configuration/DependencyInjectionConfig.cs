using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Identidade.API.Application;
using Shopping.Identidade.API.Models.Interfaces;
using Shopping.Identidade.API.Shared.Notification;

namespace Shopping.Identidade.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddMessageBusConfiguration();
        }
    }
}
