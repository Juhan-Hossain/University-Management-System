using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class Adding_Check_Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_LengthOfDeptName",
                table: "Departments",
                sql: "len(name) >= 7");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_LengthOfCode",
                table: "Departments",
                sql: "len(code) >= 2 and len(code) <= 7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_LengthOfDeptName",
                table: "Departments");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_LengthOfCode",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }
    }
}
