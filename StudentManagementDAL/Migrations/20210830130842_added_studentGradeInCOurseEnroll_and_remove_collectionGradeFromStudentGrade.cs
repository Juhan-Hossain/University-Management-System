using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class added_studentGradeInCOurseEnroll_and_remove_collectionGradeFromStudentGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_StudentGrades_StudentGradeGrade",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_StudentGradeGrade",
                table: "StudentGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "StudentGradeGrade",
                table: "StudentGrades");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "CourseEnrolls",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "CourseEnrolls");

            migrationBuilder.AddColumn<string>(
                name: "StudentGradeGrade",
                table: "StudentGrades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Code", "DepartmentId" });

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
    }
}
