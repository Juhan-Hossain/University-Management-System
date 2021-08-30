using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixingcourse_assign_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Code", "DepartmentId", "TeacherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Code", "DepartmentId" });
        }
    }
}
