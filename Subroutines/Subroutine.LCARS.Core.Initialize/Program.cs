using System;
using LCARS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Subroutine.LCARS.Core.Initialize
{
    internal partial class Program
    {
        static void Main(string[] args) => CreateHostBuilder(args)
            .Build()
            .CreateDbIfNotExists()
            .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;
                var provider = configuration.GetValue("Provider", "Sqlite").ToLower();

                services.AddDbContext<LcarsDatabase>(
                    options => _ = provider switch
                    {
                        "sqlite" => options.UseSqlite(configuration.GetConnectionString("SqliteConnection")),
                        "sqlserver" => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"), s => s.MigrationsAssembly("LCARS.Core.Migrations")),
                        _ => throw new InvalidOperationException($"Unsupported provider: {provider}")
                    });
            });
    }
}
