using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MotorDeRegras.Domain.Interface.Repository;
using MotorDeRegras.Domain.Interface.Service;
using MotorDeRegras.Domain.Interface.UOW;
using MotorDeRegras.Domain.Service.Persistence;
using MotorDeRegras.Infrastructure.Data.Context;
using MotorDeRegras.Infrastructure.Data.Interface;
using MotorDeRegras.Infrastructure.Data.Repository;
using MotorDeRegras.Infrastructure.Data.UOW;
using System;
using System.IO;
using System.Reflection;

namespace MotorDeRegras.Api
{
    public class Startup
    {
        private void AddDependency(IServiceCollection services)
        {
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositórios
            services.AddScoped<IContextoRepository, ContextoRepository>();
            //Serviços
            services.AddScoped<IContextoPersistenceService, ContextoPersistenceService>();
        }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - Motor de Regras",
                    Description = "Descrição da API",
                    Version = "v1"
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            AddDependency(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Motor de Regras");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc()
                .UseMvcWithDefaultRoute();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
