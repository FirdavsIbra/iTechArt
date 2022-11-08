using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace iTechArt.Database.Migrations
{
    public partial class ProblemsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AirportName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    BuiltDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    City = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    EmpoyeesCount = table.Column<int>(type: "integer", nullable: false),
                    PassengersPerYear = table.Column<long>(type: "bigint", nullable: false),
                    FlightsPerYear = table.Column<long>(type: "bigint", nullable: false),
                    AverageTicketPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    last_Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<byte>(type: "smallint", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    job_title = table.Column<string>(type: "text", nullable: true),
                    department_retail = table.Column<string>(type: "text", nullable: true),
                    salary = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Police",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Police", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    LastName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Address = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    City = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    SchoolName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Grade = table.Column<byte>(type: "smallint", nullable: false),
                    CourseLanguage = table.Column<byte>(type: "smallint", nullable: false),
                    Shift = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    LastName = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    Email = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Address = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    HospitalName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    Shift = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Majority = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    University = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "Police");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
