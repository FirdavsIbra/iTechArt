using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTechArt.Database.Migrations
{
    public partial class policeModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Police");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Police",
                newName: "WeightInKg");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Police",
                newName: "JobStartDate");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Police",
                newName: "HeightInCm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightInKg",
                table: "Police",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "JobStartDate",
                table: "Police",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "HeightInCm",
                table: "Police",
                newName: "Height");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Police",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
