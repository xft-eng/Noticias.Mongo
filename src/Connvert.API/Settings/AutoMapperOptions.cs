using AutoMapper;
using Connvert.Application.AutoMapperConfigs;
using Microsoft.Extensions.DependencyInjection;

namespace Connvert.API.Settings
{
    public static class AutoMapperOptions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(sp =>
                new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddAutoMapper(x => x.AddProfile(new ViewModelToDomainMappingProfile()), typeof(ViewModelToDomainMappingProfile));
            services.AddAutoMapper(x => x.AddProfile(new DomainToViewModelMappingProfile()), typeof(DomainToViewModelMappingProfile));
        }
    }
}
