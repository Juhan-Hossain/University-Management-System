using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_courseresult02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentResult_StudentGrades_GradeLetter",
                table: "StudentResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentResult",
                table: "StudentResult");

            migrationBuilder.RenameTable(
                name: "StudentResult",
                newName: "StudentResults");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResult_GradeLetter",
                table: "StudentResults",
                newName: "IX_StudentResults_GradeLetter");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResult_CourseName_StudentRegNo",
                table: "StudentResults",
                newName: "IX_StudentResults_CourseName_StudentRegNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentResults",
                table: "StudentResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResults_StudentGrades_GradeLetter",
                table: "StudentResults",
                column: "GradeLetter",
                principalTable: "StudentGrades",
                principalColumn: "Grade",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentResults_StudentGrades_GradeLetter",
                table: "StudentResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentResults",
                table: "StudentResults");

            migrationBuilder.RenameTable(
                name: "StudentResults",
                newName: "StudentResult");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResults_GradeLetter",
                table: "StudentResult",
                newName: "IX_StudentResult_GradeLetter");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResults_CourseName_StudentRegNo",
                table: "StudentResult",
                newName: "IX_StudentResult_CourseName_StudentRegNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentResult",
                table: "StudentResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResult_StudentGrades_GradeLetter",
                table: "StudentResult",
                column: "GradeLetter",
                principalTable: "StudentGrades",
                principalColumn: "Grade",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
