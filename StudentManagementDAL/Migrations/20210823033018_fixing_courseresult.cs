using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_courseresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentGradeGrade",
                table: "StudentGrades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StudentGradeGrade",
                table: "StudentGrades",
                column: "StudentGradeGrade");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_StudentGrades_StudentGradeGrade",
                table: "StudentGrades",
                column: "StudentGradeGrade",
                principalTable: "StudentGrades",
                principalColumn: "Grade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_StudentGrades_StudentGradeGrade",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_StudentGradeGrade",
                table: "StudentGrades");

            migrationBuilder.DropColumn(
                name: "StudentGradeGrade",
                table: "StudentGrades");
        }
    }
}
