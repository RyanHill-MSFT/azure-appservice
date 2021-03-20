using LCARS.Core.Crew;
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

            builder.HasKey(b => b.StarlogId);
            builder.Property(b => b.Title)
                .HasMaxLength(255);
            builder.Property(b => b.Entry);
            builder.Property(b => b.Vessel).IsRequired();
        }
    }
}
