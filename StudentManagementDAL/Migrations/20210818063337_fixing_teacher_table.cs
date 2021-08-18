using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_teacher_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Contact",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "RemainingCredit",
                table: "Teachers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Contact", "RemainingCredit" },
                values: new object[] { 123445L, 97.0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Contact", "CreditTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { 3, "adafsf", 12312445L, 30.0, 2, 1, "ashek@gmail.com", "Ashek", 70.0 });

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CreditToBeTakenByTeacher",
                table: "Teachers",
                sql: "CreditTaken >= 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_CreditToBeTakenByTeacher",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "RemainingCredit",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Contact",
                value: 123445);
        }
    }
}
