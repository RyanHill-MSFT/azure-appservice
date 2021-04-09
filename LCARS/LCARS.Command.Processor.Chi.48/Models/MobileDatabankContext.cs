using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;

namespace LCARS.Command.Processor.Chi._48.Models
{
    public class MobileDatabankContext : DbContext
    {
        public MobileDatabankContext()
            : base("Name=DatabaseUplinkConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceColumnTable",
                    (property, attributes) => attributes.Single().ColumnType.ToString()));

            modelBuilder.Entity<Candidate>().ToTable("Candidate");
        }

        public DbSet<Candidate> Candidates { get; set; }
    }
}