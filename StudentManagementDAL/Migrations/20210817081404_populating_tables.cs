using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class populating_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[,]
                {
                    { "CSE-0101", 2, 3f, "", "C", 1, 1 },
                    { "CSE-0102", 2, 3f, "", "C++", 1, 1 },
                    { "CSE-0103", 2, 3f, "", "Compiler", 1, 1 },
                    { "CSE-0104", 2, 3f, "", "Database", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Contact", "CreditTaken", "DepartmentId", "DesignationId", "Email", "Name" },
                values: new object[] { 2, "fjdsf", 123445, 3.0, 2, 2, "saif@gmail.com", "Ezaz Raihan" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Email",
                table: "Teachers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Name",
                table: "Teachers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_Email",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Name",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0101", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0102", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0103", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0104", 2 });

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
