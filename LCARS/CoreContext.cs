using LCARS.Database.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LCARS
{
    public class CoreContext : DbContext
    {
        public DbSet<Personal> PersonnelLogs { get; set; }

        public static readonly ILoggerFactory CoreContextFactory = LoggerFactory.Create(builder => builder.AddDebug());

        public CoreContext(DbContextOptions<CoreContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLoggerFactory(CoreContextFactory);
    }
}
