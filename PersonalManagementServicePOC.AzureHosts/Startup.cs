using AutoMapper;
using DependencyRegistrar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PersonalManagementServicePOC.Application.Mapping;
using Repository.PersonalManagementServicePOC.Context.Implementation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PersonalManagementServicePOC.AzureHosts
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();

            //IConfigurationSection sec = Configuration.GetSection("OrdersService");
            //services.Configure<OrderOptions>(sec);

            var assembly = Assembly.Load("PersonalManagementServicePOC.Application");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddApplicationPart(assembly).AddControllersAsServices(); ;

            services.AddOptions();
            services.AddDbContext<CommitteeContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DB")));

            ContainerConfig.Configure(services, Configuration);

            services.AddAutoMapper(typeof(MapperConfig));
            MapperConfig.RegisterMappings();

            services.AddRouting();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Personal Management Microservice", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            loggerFactory.AddConsole(); ///.AddFile("Logs/{Date}.txt");
            //app.UseHttpsRedirection();
            app.UseCors();

            //app..UseRouting();

            app.ConfigureGloabalExceptionMiddleware();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Personal Management Microservice"));
        }
    }
}
