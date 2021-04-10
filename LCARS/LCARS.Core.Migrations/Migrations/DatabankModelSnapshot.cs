﻿// <auto-generated />
using System;
using LCARS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LCARS.Core.Migrations
{
    [DbContext(typeof(Databank))]
    partial class DatabankModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LCARS.Core.Data.Crew.Officer", b =>
                {
                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Assignment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Station")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialNo");

                    b.ToTable("Officer");
                });

            modelBuilder.Entity("LCARS.Core.Data.Logs.Starlog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("LogType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vessel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Starlog");
                });

            modelBuilder.Entity("LCARS.Core.Data.Crew.PersonalLog", b =>
                {
                    b.HasBaseType("LCARS.Core.Data.Logs.Starlog");

                    b.Property<string>("Entry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToTable("PersonLog");
                });

            modelBuilder.Entity("LCARS.Core.Data.Crew.PersonalLog", b =>
                {
                    b.HasOne("LCARS.Core.Data.Logs.Starlog", null)
                        .WithOne()
                        .HasForeignKey("LCARS.Core.Data.Crew.PersonalLog", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
