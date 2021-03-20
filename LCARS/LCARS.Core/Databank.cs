using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Configurations.Sql;
using LCARS.Core.Crew;
using LCARS.Core.Logs;
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
            modelBuilder.Entity<Officer>(b =>
            {
                b.ToTable(OfficerConfiguration.TableName);
                b.HasKey(p => p.SerialNo);
            });
            modelBuilder.Entity<Starlog>(b =>
            {
                b.ToTable(StarlogConfiguration.TableName);
            });
            modelBuilder.Entity<PersonalLog>(b =>
            {
                b.ToTable(PersonalLogConfiguration.TableName);
            });
        }

        public DbSet<PersonalLog> PersonalLogs { get; set; }
        public DbSet<Officer> Officers { get; set; }
    }
}
