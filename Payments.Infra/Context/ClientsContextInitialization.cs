using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Infrastructure.Context
{
    public static class ClientsContextInitialization
    {
        public static void EnsureMigrationOfContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetService<ClientsContext>();
            {
                context.Database.EnsureCreated();
            }
        }
    }
}