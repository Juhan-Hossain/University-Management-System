using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class checking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_StudentGrades_Grade1",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_Grade1",
                table: "CourseEnrolls");*/

       /*     migrationBuilder.DropColumn(
                name: "Grade1",
                table: "CourseEnrolls");*/

            migrationBuilder.AddColumn<string>(
                name: "GradeLetter",
                table: "CourseEnrolls",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeLetter",
                table: "CourseEnrolls");

           /* migrationBuilder.AddColumn<string>(
                name: "Grade1",
                table: "CourseEnrolls",
                type: "nvarchar(450)",
                nullable: true);*/

           /* migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_Grade1",
                table: "CourseEnrolls",
                column: "Grade1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_StudentGrades_Grade1",
                table: "CourseEnrolls",
                column: "Grade1",
                principalTable: "StudentGrades",
                principalColumn: "Grade",
                onDelete: ReferentialAction.Restrict);*/
        }
    }
}
