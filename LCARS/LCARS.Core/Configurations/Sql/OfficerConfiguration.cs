using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Crew;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCARS.Core.Configurations.Sql
{
    internal class OfficerConfiguration : IEntityTypeConfiguration<Officer>
    {
        public const string TableName = "Officer";

        public void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder.ToTable(TableName);
        }

        public static Officer[] TheNextGeneration => new Officer[]
        {
                new Officer
                {
                    Department = DepartmentArea.Command,
                    Rank = StarfleetRank.Captain,
                    FirstName = "Jean-Luc",
                    LastName = "Picard",
                    Assignment = "USS Enterprise"
                },
                new Officer
                {
                    Department = DepartmentArea.Command,
                    Rank = StarfleetRank.Commander,
                    FirstName = "William",
                    MiddleName = "Thomas",
                    LastName = "Riker",
                    Assignment = "USS Enterprise"
                },
                new Officer
                {
                    Department = DepartmentArea.Operations,
                    Rank = StarfleetRank.LieutenantCommander,
                    FirstName = "Data",
                    Assignment = "USS Enterprise"
                },
                new Officer
                {
                    Department = DepartmentArea.Operations,
                    Rank = StarfleetRank.LieutenantCommander,
                    FirstName = "Geordi",
                    LastName = "LaForge",
                    Assignment = "USS Enterprise"
                },
                new Officer
                {
                    Department = DepartmentArea.Sciences,
                    Rank = StarfleetRank.LieutenantCommander,
                    FirstName = "Deanna",
                    LastName = "Troi",
                    Assignment = "USS Enterprise"
                }
        };

        public static Officer[] DeepSpaceNine => new Officer[]
        {
            new Officer
            {
                Department = DepartmentArea.Command,
                Rank = StarfleetRank.Captain,
                FirstName = "Benjamin",
                MiddleName = "LaFayette",
                LastName = "Sisko",
                Assignment = "Deep Space Nine"
            }
        };
    }
}
