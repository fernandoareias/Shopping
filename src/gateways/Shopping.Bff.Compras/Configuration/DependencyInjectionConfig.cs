using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shopping.WebAPI.Core.Usuario;

namespace Shopping.Bff.Compras.Configuration.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }
}