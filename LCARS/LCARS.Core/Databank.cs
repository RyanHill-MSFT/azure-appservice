using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Crew;
using LCARS.Core.Logs;
using LCARS.Core.Positional;
using Microsoft.EntityFrameworkCore;

namespace LCARS.Core
{
    public class Databank : DbContext
    {
        public Databank(DbContextOptions<Databank> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<PersonalLog> PersonalLogs { get; set; }
        public DbSet<Officer> Officers { get; set; }
    }
}
