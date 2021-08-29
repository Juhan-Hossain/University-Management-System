using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_teacher_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Contact", "CreditToBeTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { 1, "fjdsf", 123445L, 100.0, 2, 2, "saif@gmail.com", "Ezaz Raihan", 97.0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Contact", "CreditToBeTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { 2, "adafsf", 12312445L, 100.0, 2, 1, "ashek@gmail.com", "Ashek", 70.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Email",
                table: "Teachers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Name",
                table: "Teachers",
                column: "Name",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CreditToBeTakenByTeacher",
                table: "Teachers",
                sql: "CreditToBeTaken >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_RemainingCreditOfTeacher",
                table: "Teachers",
                sql: "RemainingCredit BETWEEN 0 AND CreditToBeTaken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_Email",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Name",
                table: "Teachers");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CreditToBeTakenByTeacher",
                table: "Teachers");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_RemainingCreditOfTeacher",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
