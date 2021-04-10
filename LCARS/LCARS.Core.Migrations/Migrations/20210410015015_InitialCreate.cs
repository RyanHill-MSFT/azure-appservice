using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCARS.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    SerialNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Station = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.SerialNo);
                });

            migrationBuilder.CreateTable(
                name: "Starlog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vessel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Entry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLog_Starlog_Id",
                        column: x => x.Id,
                        principalTable: "Starlog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropTable(
                name: "PersonLog");

            migrationBuilder.DropTable(
                name: "Starlog");
        }
    }
}
