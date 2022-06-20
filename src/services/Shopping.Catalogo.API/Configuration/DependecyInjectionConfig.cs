using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Catalogo.API.Data;
using Shopping.Catalogo.API.Data.Repositories;
using Shopping.Catalogo.API.Models.Interfaces;
using Shopping.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Catalogo.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection UseDependencyInjectionConfig(this IServiceCollection service)
        {
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IUnitOfWork, CatalogoContext>();

            return service;
        }
    }
}
