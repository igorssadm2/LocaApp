using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Configuration
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                //options.CreateMap<ClienteRegistroViewModel, ClienteModel>();
                //options.CreateMap<ClienteEditarViewModel, ClienteModel>();
            });

            return services;
        }
    }
}
