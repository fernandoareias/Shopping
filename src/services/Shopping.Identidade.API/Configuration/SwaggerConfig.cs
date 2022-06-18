using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection UseAddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Shopping Identidade API",
                    Description = "Esta API faz parte do projeto Shopping",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Fernando Areias", Email = "nando.calheirosx@gmail.com" },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
                });
            });

            return service;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder configuration)
        {
            configuration.UseSwagger();
            configuration.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

            return configuration;
        }
    }
}
