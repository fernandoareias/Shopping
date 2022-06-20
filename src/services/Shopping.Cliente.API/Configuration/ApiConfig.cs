using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.Cliente.API.Data;
using Shopping.Core.WebAPI.Identidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection UseAddApiService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ClientesContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            service.AddControllers();

            service.AddCors(options => 
            {
                options.AddPolicy(name: "Total", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

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

            app.UseCors("Total");

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
