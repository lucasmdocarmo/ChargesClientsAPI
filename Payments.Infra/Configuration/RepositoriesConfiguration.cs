using Microsoft.Extensions.DependencyInjection;
using Payments.Clientes.Domain.Contracts.Repository;
using Payments.Clientes.Infrastructure.Context;
using Payments.Clientes.Infrastructure.Repository;
using Payments.Core.Shared.Contracts.UnitOfWork;
using Payments.Core.Shared.Repository;
using Payments.Core.Shared.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Infrastructure.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ClientsContext>();
            services.AddScoped<IUnitOfWork, ClientsContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
