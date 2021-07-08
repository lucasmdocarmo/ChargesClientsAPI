using Microsoft.Extensions.DependencyInjection;
using Payments.Application.UseCases.DisplayClient.Ports;
using Payments.Application.UseCases.DisplayClient.Presenter;
using Payments.Clientes.Application.UseCases.CreateClient.Ports;
using Payments.Clientes.Application.UseCases.CreateClient.Presenter;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Presentation;
using Payments.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Application.Configuration
{
    public static class PresenterConfiguration
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBasePresenter, BasePresenter>();
            services.AddScoped<ICreateClientPort, CreateClientPresenter>();
            services.AddScoped<IDisplayClientPort, DisplayClientPresenter>();

            services.AddScoped<CreateClientPresenter>();
            services.AddScoped<DisplayClientPresenter>();

            return services;
        }
    }
}
