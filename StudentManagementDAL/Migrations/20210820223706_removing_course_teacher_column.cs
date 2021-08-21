using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class removing_course_teacher_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Teachers_TeacherId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_TeacherId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "EEE", "Electronics & Electrical Engineering" },
                    { 2, "CSE", "Computer Science & Engineering" },
                    { 3, "CE", "Civil Engineering" },
                    { 4, "ME", "Mechanical Engineering" },
                    { 5, "MTE", "Mechatronics Engineering" },
                    { 6, "IPE", "Industrial Production & Engineering" },
                    { 7, "MME", "Department of Materials and Metallurgical Engineering" }
                });

            migrationBuilder.InsertData(
                table: "StudentGrades",
                column: "Grade",
                values: new object[]
                {
                    "D",
                    "D+",
                    "C-",
                    "C",
                    "C+",
                    "A-",
                    "B",
                    "B+",
                    "D-",
                    "A",
                    "A+",
                    "B-",
                    "F"
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_Code",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A-");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "A+");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B-");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "B+");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C-");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "C+");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D-");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "D+");

            migrationBuilder.DeleteData(
                table: "StudentGrades",
                keyColumn: "Grade",
                keyValue: "F");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Departments",
                type: "int",
                nullable: true);

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
        }
    }
}
