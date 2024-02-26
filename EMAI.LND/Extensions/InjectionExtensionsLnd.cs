using EMAI.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND.Extensions
{
    public static class InjectionExtensionsLnd
    {
        public static IServiceCollection AddInjectionLdn (this IServiceCollection services,IConfiguration _configuration) {


            services.AddSingleton(_configuration);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPromosionesOperaciones, PromosionesOperaciones>();
            return services;

        }
    }
}
