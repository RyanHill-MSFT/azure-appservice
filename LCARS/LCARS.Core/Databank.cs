using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Configurations.Sql;
using LCARS.Core.Data.Crew;
using LCARS.Core.Data.Logs;
using Microsoft.EntityFrameworkCore;

namespace LCARS.Core
{
    public sealed class Databank : DbContext
    {
        public Databank(DbContextOptions<Databank> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StarlogConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalLogConfiguration());
            modelBuilder.ApplyConfiguration(new OfficerConfiguration());
        }

        public DbSet<PersonalLog> PersonalLogs { get; set; }
        public DbSet<Officer> Officers { get; set; }
    }
}
