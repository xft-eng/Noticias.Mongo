using Connvert.API.Settings;
using Connvert.Application.Validator;
using Connvert.Infrastructure.Data.DbContext;
using Connvert.Infrastructure.IoC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Connvert.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(DatabaseConfig)));
            services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

            services.AddControllers()
                 .AddFluentValidation(fv =>
                 {
                     fv.RegisterValidatorsFromAssemblyContaining<NoticiaValidator>();
                 });

            services.AddResponseCaching();

            services.AddOptions();

            services.AddCors();

            services.AddMemoryCache();



            services.AddSwagger();

            services.AddAutoMapper();

            services.RegisterDependencyInjectionServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/api/erros");
            }

            app.UseCors(x => x
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
