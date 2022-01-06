using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Havan.Desafio.DataAccess.Entities;
using Havan.Desafio.WebApi.Configs;
using Havan.Desafio.DataAccess;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using OData.Swagger.Services;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData;

namespace Havan.Desafio.WebApi
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
            services.AddControllers().AddOData(options =>
                options.Select().Filter().OrderBy().Expand());

            services.AddSingleton<IConfiguration>(Configuration);// aqui

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Havan.Desafio.WebApi",
                    Version = "v1"
                });
            });

            services.AddOdataSwaggerSupport();

            services.AddDbContext<HavanContext>();
            services.AddTransient<ITenantProvider, HttpTenantProvider>();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();

            services.AddMvc(options => { options.Filters.Add(typeof(ModelStateValidationFilter)); });
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData6Demo.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
