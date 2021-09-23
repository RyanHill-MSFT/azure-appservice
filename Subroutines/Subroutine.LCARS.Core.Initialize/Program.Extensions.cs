using System;
using LCARS.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Subroutine.LCARS.Core.Initialize
{
    static class Extensions
    {
        public static IHost CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LcarsDatabase>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred initializing data bank");
                }
            }
            return host;
        }
    }
}
