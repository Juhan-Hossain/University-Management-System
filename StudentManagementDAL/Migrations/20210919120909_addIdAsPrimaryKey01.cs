using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class addIdAsPrimaryKey01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseId",
                table: "CourseEnrolls");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_EnrolledCourseId",
                table: "CourseEnrolls",
                column: "EnrolledCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_EnrolledCourseId",
                table: "CourseEnrolls",
                column: "EnrolledCourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_EnrolledCourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_EnrolledCourseId",
                table: "CourseEnrolls");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseId",
                table: "CourseEnrolls",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseId",
                table: "CourseEnrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
