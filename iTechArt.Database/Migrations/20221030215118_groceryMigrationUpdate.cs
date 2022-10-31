using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTechArt.Database.Migrations
{
    public partial class groceryMigrationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Groceries",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Groceries",
                newName: "Job_Title");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Groceries",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentRetail",
                table: "Groceries",
                newName: "Department_Retail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Groceries",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Job_Title",
                table: "Groceries",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Groceries",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Department_Retail",
                table: "Groceries",
                newName: "DepartmentRetail");
        }
    }
}
