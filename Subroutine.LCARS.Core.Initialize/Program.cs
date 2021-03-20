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
                var provider = configuration.GetValue("Provider", "SqlServer");

                services.AddDbContext<Databank>(
                    options => _ = provider switch
                    {
                        "Sqlite" => options.UseSqlite(configuration.GetConnectionString("SqliteConnection")),
                        "SqlServer" => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")),
                        _ => throw new InvalidOperationException($"Unsupported provider: {provider}")
                    });
            });
    }
}
