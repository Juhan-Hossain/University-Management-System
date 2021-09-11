using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class addedValueToGrade01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "value",
                table: "StudentGrades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A-",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A+",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B-",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B+",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C-",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C+",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D-",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D+",
                column: "value",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "F",
                column: "value",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "value",
                table: "StudentGrades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A-",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A+",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B-",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B+",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C-",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C+",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D-",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D+",
                column: "value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "F",
                column: "value",
                value: 0);
        }
    }
}
