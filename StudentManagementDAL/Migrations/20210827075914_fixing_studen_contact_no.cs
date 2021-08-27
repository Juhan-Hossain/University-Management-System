using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_studen_contact_no : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_ContactNumber",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ContactNumber",
                table: "Students",
                column: "ContactNumber",
                unique: true,
                filter: "[ContactNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_ContactNumber",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ContactNumber",
                table: "Students",
                column: "ContactNumber",
                unique: true);
        }
    }
}
