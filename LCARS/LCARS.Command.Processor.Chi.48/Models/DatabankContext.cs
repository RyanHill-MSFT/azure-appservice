using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using LCARS.Core.Data.Crew;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;

namespace LCARS.Command.Processor.Chi._48.Models
{
    public class DatabankContext : DbContext
    {
        public DatabankContext()
            : base("Name=DatabaseUplink")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceColumnTable",
                    (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public DbSet<PersonalLog> PersonLogs { get; set; }

        public DbSet<Officer> Officers { get; set; }
    }
}