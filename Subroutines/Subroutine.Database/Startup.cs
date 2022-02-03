using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subroutine.Database.Data;
using Subroutine.Database.Services;

[assembly: FunctionsStartup(typeof(Subroutine.Database.Startup))]
namespace Subroutine.Database
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<AzureStorageConfig>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(nameof(AzureStorageConfig)).Bind(settings);
                });
            builder.Services.AddScoped<StorageManager>();
            builder.Services.AddScoped<BiographicalDataContext>();
        }
    }
}
