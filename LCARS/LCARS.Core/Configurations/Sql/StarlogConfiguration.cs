using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Data.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCARS.Core.Configurations.Sql
{
    internal class StarlogConfiguration : IEntityTypeConfiguration<Starlog>
    {
        public const string TableName = "Starlog";

        public void Configure(EntityTypeBuilder<Starlog> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(b => b.Id);
        }
    }
}
