using LCARS.Core.Data.Crew;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCARS.Core.Configurations.Sql
{
    internal class PersonalLogConfiguration : IEntityTypeConfiguration<PersonalLog>
    {
        public const string TableName = "PersonLog";

        public void Configure(EntityTypeBuilder<PersonalLog> builder)
        {
            builder.ToTable(TableName);

            builder.Property(b => b.Title).HasMaxLength(255);
        }
    }
}
