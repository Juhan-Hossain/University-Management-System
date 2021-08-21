using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_little_bugOnApplicationDbContext01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CourseAssignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Code", "DepartmentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CourseAssignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                column: "Id");
        }
    }
}
