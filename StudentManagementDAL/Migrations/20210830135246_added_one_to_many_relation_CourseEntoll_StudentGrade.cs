using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class added_one_to_many_relation_CourseEntoll_StudentGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "CourseEnrolls");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "CourseEnrolls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_Grade1",
                table: "CourseEnrolls",
                column: "Grade");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_StudentGrades_Grade",
                table: "CourseEnrolls",
                column: "Grade",
                principalTable: "StudentGrades",
                principalColumn: "Grade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_StudentGrades_Grade",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_Grade",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "CourseEnrolls");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "CourseEnrolls",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
