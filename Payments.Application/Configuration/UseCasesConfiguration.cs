using Microsoft.Extensions.DependencyInjection;
using Payments.Core.Shared.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Assembly;

namespace Payments.Clientes.Application.Configuration
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddRegisterUseCases(this IServiceCollection services)
        {
            GetExecutingAssembly().GetTypes().
            Where(item => item.GetInterfaces().
            Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IUseCase<>)) && !item.IsAbstract && !item.IsInterface).
            ToList().
            ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IUseCase<>));
                services.AddScoped(serviceType, assignedTypes);

            });

            return services;
        }
    }
}
