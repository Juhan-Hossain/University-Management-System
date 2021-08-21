using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class courses_table_populating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses");

            /*migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0101", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0102", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0103", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0104", 2 });

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);*/

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

           /* migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Contact", "CreditTaken", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { "adafsf", 12312445L, 30.0, 1, "avishek@gmail.com", "Avishek", 70.0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Contact", "CreditTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { 1, "fjdsf", 123445L, 3.0, 2, 2, "saif@gmail.com", "Ezaz Raihan", 97.0 });*/

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[] { "CSE-0101", 2, 3f, "", "C", 1, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[] { "CSE-0102", 2, 3f, "", "C++", 1, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[] { "CSE-0103", 2, 3f, "", "Compiler", 1, 1 });

           /* migrationBuilder.AddCheckConstraint(
                name: "CHK_RemainingCreditOfTeacher",
                table: "Teachers",
                sql: "RemainingCredit BETWEEN 1 AND CreditTaken");*/

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_RemainingCreditOfTeacher",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0101", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0102", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-0103", 2 });

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[,]
                {
                    { "CSE-0101", 2, 3f, "", "C", 1, 1 },
                    { "CSE-0102", 2, 3f, "", "C++", 1, 1 },
                    { "CSE-0103", 2, 3f, "", "Compiler", 1, 1 },
                    { "CSE-0104", 2, 3f, "", "Database", 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2,
                columns: new[] { "Address", "Contact", "CreditTaken", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { "fjdsf", 123445L, 3.0, 2, "saif@gmail.com", "Ezaz Raihan", 97.0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Address", "Contact", "CreditTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[] { 3, "adafsf", 12312445L, 30.0, 2, 1, "ashek@gmail.com", "Ashek", 70.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
