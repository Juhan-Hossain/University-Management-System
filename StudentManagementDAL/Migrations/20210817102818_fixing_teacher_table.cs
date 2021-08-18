using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_teacher_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designations_TeacherId",
                table: "Designations",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_TeacherId",
                table: "Departments",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Teachers_TeacherId",
                table: "Departments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Teachers_TeacherId",
                table: "Designations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Teachers_TeacherId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Teachers_TeacherId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Designations_TeacherId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_TeacherId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Departments");
        }
    }
}
