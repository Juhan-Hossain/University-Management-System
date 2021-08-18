using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherId");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Semesters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1st" },
                    { 2, "2nd" },
                    { 3, "3rd" },
                    { 4, "4th" },
                    { 5, "5th" },
                    { 6, "6th" },
                    { 7, "7th" },
                    { 8, "8th" }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2,
                columns: new[] { "Contact", "RemainingCredit" },
                values: new object[] { 123445L, 97.0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Address", "Contact", "CreditTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { 3, "adafsf", 12312445L, 30.0, 2, 1, "ashek@gmail.com", "Ashek", 70.0 });

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CreditToBeTakenByTeacher",
                table: "Teachers",
                sql: "CreditTaken >= 0");

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
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Teachers_TeacherId",
                table: "Designations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
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

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CreditToBeTakenByTeacher",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Designations_TeacherId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_TeacherId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "RemainingCredit",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Semesters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Contact",
                value: 123445);
        }
    }
}
