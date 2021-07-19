using System;
using System.Collections.Generic;
using System.Text;
using LCARS.Core.Data.Crew;
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
            builder.HasKey(p => p.SerialNo);
            //builder.HasData(TheNextGeneration, DeepSpaceNine);
        }

        public static Officer[] TheNextGeneration => new[]
        {
                new Officer
                {
                    Department = DepartmentArea.Command,
                    Rank = StarfleetRank.Captain,
                    FirstName = "Jean-Luc",
                    LastName = "Picard",
                    SerialNo = "SP-937-215",
                    Assignment = "Commanding Officer"
                },
                new Officer
                {
                    Department = DepartmentArea.Command,
                    Rank = StarfleetRank.Commander,
                    FirstName = "William",
                    MiddleName = "Thomas",
                    LastName = "Riker",
                    SerialNo = "SC-231-427",
                    Assignment = "Executive Officer"
                },
                new Officer
                {
                    Department = DepartmentArea.Operations,
                    Rank = StarfleetRank.Lieutenant & StarfleetRank.Commander,
                    FirstName = "Data",
                    Assignment = "Second Officer"
                },
                new Officer
                {
                    Department = DepartmentArea.Operations,
                    Rank = StarfleetRank.Lieutenant & StarfleetRank.Commander,
                    FirstName = "Geordi",
                    LastName = "LaForge",
                    Assignment = "Chief Engineer"
                },
                new Officer
                {
                    Department = DepartmentArea.Sciences,
                    Rank = StarfleetRank.Lieutenant & StarfleetRank.Commander,
                    FirstName = "Deanna",
                    LastName = "Troi",
                    Assignment = "Counselor"
                },
                new Officer
                {
                    Department = DepartmentArea.Medical,
                    Rank = StarfleetRank.Lieutenant & StarfleetRank.Commander,
                    FirstName = "Beverly",
                    LastName = "Crusher",
                    Assignment = "Chief Medical Officer"
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
                SerialNo = Officer.GenerateSerialNumber(),
                Assignment = "Deep Space Nine"
            }
        };
    }
}
