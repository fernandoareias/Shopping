using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;


namespace Shopping.Pedido.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection UseAddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Shopping Pedido API",
                    Description = "Esta API faz parte do projeto Shopping",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Fernando Areias", Email = "nando.calheirosx@gmail.com" },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
                { 
                    Description = "Insira o token JWT desta maneira: Bearer [TOKEN]",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference =  new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return service;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder configuration)
        {
            configuration.UseSwagger();
            configuration.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

            return configuration;
        }
    }
}
