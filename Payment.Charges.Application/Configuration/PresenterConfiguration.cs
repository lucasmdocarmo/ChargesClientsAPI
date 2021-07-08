using Microsoft.Extensions.DependencyInjection;
using Payments.Charges.Application.UseCases.DisplayCharge.Ports;
using Payments.Charges.Application.UseCases.DisplayCharge.Presenter;
using Payments.Charges.Application.UseCases.RegisterCharge.Ports;
using Payments.Charges.Application.UseCases.RegisterCharge.Presenter;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.Configuration
{
    public static class PresenterConfiguration
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBasePresenter, BasePresenter>();
            services.AddScoped<IDisplayChargePort, DisplayChargesPresenter>();
            services.AddScoped<IRegisterChargePort, RegisterChargePresenter>();

            services.AddScoped<DisplayChargesPresenter>();
            services.AddScoped<RegisterChargePresenter>();

            return services;
        }
    }
}
