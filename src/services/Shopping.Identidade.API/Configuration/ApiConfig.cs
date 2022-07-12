using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.Identidade.API.Data;
using Shopping.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection UseAddApiService(this IServiceCollection service, IConfiguration configuration)
        {
            service
                .AddDbContext<ApplicationDbContext>(
                    options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                    )
                );

            service.AddControllers();
            service.AddMessageBus(configuration.GetSection("MessageQueueConnection")?["MessageBus"]);
            return service;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            return app;
        }
    }
}
