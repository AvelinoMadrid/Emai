using EMAI.LND.Validators;
using EMAI.Servicios;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EMAI.LND.Extensions.InjectionExtensionsLnd;

namespace EMAI.LND.Extensions
{
    public static class InjectionExtensionsLnd
    {
        public static IServiceCollection AddInjectionLdn (this IServiceCollection services,IConfiguration _configuration) {

            services.AddSingleton(_configuration);
            
            //AddFluentValidation

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(P => !P.IsDynamic));
            });

            services.AddHttpContextAccessor();  
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPromosionesOperaciones, PromosionesOperaciones>();
            services.AddTransient<IPrograma5sOperaciones, Programa5sOperaciones>();
            services.AddTransient<IAlumnosOperaciones, AlumnosOperaciones>();
            services.AddTransient<IMesesOperaciones, MesesOperaciones>();
            services.AddSingleton<IContendorImagenes, ContendorImagenes>();
            return services;
        }
    }
}
