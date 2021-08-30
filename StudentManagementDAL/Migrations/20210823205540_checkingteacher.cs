using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class checkingteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_TeacherId",
                table: "CourseAssignments",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Teachers_TeacherId",
                table: "CourseAssignments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Teachers_TeacherId",
                table: "CourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_TeacherId",
                table: "CourseAssignments");
        }
    }
}
