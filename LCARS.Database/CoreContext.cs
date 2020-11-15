using LCARS.Database.Models.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LCARS.Database
{
    public class CoreContext : DbContext
    {
        public DbSet<PersonalLog> PersonnelLogs { get; set; }

        public static readonly ILoggerFactory CoreContextFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        public CoreContext(DbContextOptions<CoreContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLoggerFactory(CoreContextFactory);
    }
}
