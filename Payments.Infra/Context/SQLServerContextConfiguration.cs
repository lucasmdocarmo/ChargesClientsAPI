using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Infrastructure.Context
{
    public static class SQLServerContextConfiguration
    {
        public static IServiceCollection AddSQLServerConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var server = config["DbServer"] ?? "localhost";
            var port = config["DbPort"] ?? "1433"; // Default SQL Server port
            var user = config["DbUser"] ?? "SA"; 
            var password = config["Password"] ?? "stone#2021";
            var database = config["Database"] ?? "Payment-ClientDb";

            string connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

            services.AddDbContext<ClientsContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
