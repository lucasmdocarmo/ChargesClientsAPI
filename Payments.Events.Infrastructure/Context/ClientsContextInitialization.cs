using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Events.Infrastructure.Context
{
    public static class ClientsContextInitialization
    {
        public static void EnsureMigrationOfContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetService<PaymentsContext>();
            {
                context.Database.EnsureCreated();
            }
        }
        public static IServiceCollection AddSQLServerConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var server = config["DbServer"] ?? "localhost";
            var port = config["DbPort"] ?? "1433"; // Default SQL Server port
            var user = config["DbUser"] ?? "SA";
            var password = config["Password"] ?? "stone#2021";
            var database = config["Database"] ?? "Payment-charges-clients-db";

            string connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

            services.AddDbContext<PaymentsContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
