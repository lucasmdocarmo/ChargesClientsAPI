using Flunt.Validations;
using Microsoft.Extensions.DependencyInjection;
using Payments.Clientes.Application.UseCases.CreateClient.Ports;
using Payments.Clientes.Application.UseCases.CreateClient.Presenter;
using Payments.Core.Shared.Contracts.Application.Ports;
using Payments.Core.Shared.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Application.Configuration
{
    public static class ValidatorsConfiguration
    {
        public static IServiceCollection AddRegisterValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(Contract<>), typeof(Contract<>));
            return services;
        }
    }
}
