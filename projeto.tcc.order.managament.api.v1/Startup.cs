using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using projeto.tcc.order.managament.api.v1.Filters;
using projeto.tcc.order.managament.application.CommandsHandlers;
using projeto.tcc.order.managament.application.QueryHandlers;
using projeto.tcc.order.managament.crosscutting.ioc;
using projeto.tcc.order.managament.crosscutting.ioc.Configuration;

namespace projeto.tcc.order.managament.api.v1
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(env.ContentRootPath)
                                    .AddJsonFile("appsettings.json", true, true)
                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);


            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("Configuracoes").Get<AppSettings>();
            //var connectionString = Environment.GetEnvironmentVariable("ConnectionString");


            services.AddDatabaseSetup();
            //services.AddHealthCheckSetup(connectionString);
            services.AddAutoMapper();
            services.AddDependencyInjectionSetup(appSettings);
            services.AddSwaggerSetup();
            services.AddMediatR(typeof(CommandHandler), typeof(QueryHandler));
            services.AddMemoryCache();
            services.AddScoped<GlobalExceptionFilterAttribute>();


            services.AddControllers();
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
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
