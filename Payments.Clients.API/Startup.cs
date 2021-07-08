using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Payments.Clientes.Application.Configuration;
using Payments.Clientes.Application.UseCases.CreateClient;
using Payments.Clientes.Infrastructure.Configuration;
using Payments.Clientes.Infrastructure.Context;
using Payments.Clients.API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Clients.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersConfiguration();
            services.AddCustomVersioning();
            services.AddRegisterServices();
            services.AddRegisterUseCases();
            services.AddRegisterValidators();
            services.AddRepositories();
            services.AddSwagger();
            services.AddSQLServerConfiguration(Configuration);
            services.AddControllers();
            services.AddHttpClient<CreateClientUseCase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.EnsureMigrationOfContext();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payments.Clients.API v1"));
            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseHsts();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
