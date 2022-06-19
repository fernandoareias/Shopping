using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shopping.Core.WebAPI.Identidade;
using Shopping.Identidade.API.Data;
using Shopping.Identidade.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection UseIdentityConfig(this IServiceCollection service, IConfiguration configuration)
        {

            service
                .AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            service.AddJwtConfiguration(configuration);
            
            return service;
        }

       
    }
}
