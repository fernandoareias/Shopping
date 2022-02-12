
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.Identidade.API.Configuration;
using Shopping.Identidade.API.Data;
using Shopping.Identidade.API.Extensions.HealthCheck;
using Shopping.Identidade.API.Services;

namespace Shopping.Identidade.API.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityConfiguration(configuration);

           

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            



            services.RegisterServices();
            
            services.AddSwaggerConfiguration();

            services.HealthCheck(configuration);

            services.AddHostedService<RemoverClienteIntegrationHandler>();
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();


            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseHealthChecks("/api/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static IServiceCollection HealthCheck(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"))                
                .AddCheck("RabbitMQ",new RabbitMQHealthCheck());

           
            return services;
        }
    }
}
