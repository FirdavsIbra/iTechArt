using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTechArt.Database.Migrations
{
    public partial class MaxLengthOfSchoolName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Groceries",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Groceries",
                newName: "last_Name");

            migrationBuilder.RenameColumn(
                name: "Job_Title",
                table: "Groceries",
                newName: "job_title");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Groceries",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Groceries",
                newName: "first_Name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Groceries",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Department_Retail",
                table: "Groceries",
                newName: "department_retail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groceries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Groceries",
                newName: "birthday");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Pupils",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_Name",
                table: "Groceries",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_Name",
                table: "Groceries",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Groceries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Groceries",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "last_Name",
                table: "Groceries",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "job_title",
                table: "Groceries",
                newName: "Job_Title");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Groceries",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "first_Name",
                table: "Groceries",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Groceries",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "department_retail",
                table: "Groceries",
                newName: "Department_Retail");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Groceries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "Groceries",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Pupils",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Groceries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Groceries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Groceries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
