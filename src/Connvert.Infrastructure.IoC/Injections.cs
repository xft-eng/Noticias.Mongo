using Connvert.Application.Interfaces;
using Connvert.Application.Service;
using Connvert.Domain.Interfaces.Repositories;
using Connvert.Domain.Services;
using Connvert.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connvert.Infrastructure.IoC
{
    public static class Injections
    {
        public static void RegisterDependencyInjectionServices(this IServiceCollection services,
           IConfiguration configuration)
        {


            //AppService
            services.AddScoped<INoticiasAppService, NoticiasAppService>();


            ////Services
            services.AddScoped<INoticiasService, NoticiasService>();

            ////Repositorios
            services.AddScoped<INoticiasRepository, NoticiasRepository>();

        }
    }
}
