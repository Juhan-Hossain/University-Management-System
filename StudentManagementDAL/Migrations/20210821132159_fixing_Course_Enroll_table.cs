using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_Course_Enroll_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseDepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "CourseEnrolls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CourseEnrolls",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CourseDepartmentId",
                table: "CourseEnrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "CourseEnrolls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "CourseDepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
