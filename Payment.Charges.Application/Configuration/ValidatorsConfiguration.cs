using Flunt.Validations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Application.Configuration
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
