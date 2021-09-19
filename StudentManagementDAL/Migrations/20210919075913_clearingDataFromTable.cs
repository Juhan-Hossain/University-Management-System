using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class clearingDataFromTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-1102", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-1103", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-1104", 2 });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

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
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

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

           /* migrationBuilder.DeleteData(
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
                keyValue: "F");*/

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "DayName",
                value: "Sat");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "DayName",
                value: "Sun");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "DayName",
                value: "Mon");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "DayName",
                value: "Tue");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "DayName",
                value: "Wed");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "DayName",
                value: "Thu");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "DayName",
                value: "Fri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "D-102" },
                    { 7, "D-101" },
                    { 6, "C-102" },
                    { 5, "C-101" },
                    { 2, "A-102" },
                    { 3, "B-101" },
                    { 1, "A-101" },
                    { 4, "B-102" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "6th" },
                    { 8, "8th" },
                    { 5, "5th" },
                    { 7, "7th" },
                    { 3, "3rd" },
                    { 2, "2nd" },
                    { 1, "1st" },
                    { 4, "4th" }
                });

          /*  migrationBuilder.InsertData(
                table: "StudentGrades",
                columns: new[] { "Grade", "value" },
                values: new object[,]
                {
                    { "F", null },
                    { "D-", null },
                    { "D", null },
                    { "D+", null },
                    { "C-", null },
                    { "C+", null },
                    { "C", null },
                    { "B", null },
                    { "B+", null },
                    { "A-", null },
                    { "A", null },
                    { "A+", null },
                    { "B-", null }
                });*/

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "DayName",
                value: "Saturday");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "DayName",
                value: "Sunday");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "DayName",
                value: "Monday");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "DayName",
                value: "Tuesday");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "DayName",
                value: "Wednessday");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "DayName",
                value: "Thursday");

            migrationBuilder.UpdateData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "DayName",
                value: "Friday");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "AssignTo", "Credit", "Description", "Id", "Name", "SemesterId", "TeacherId" },
                values: new object[,]
                {
                    { "CSE-1102", 2, null, 3f, "", 0, "C Lab", 1, null },
                    { "CSE-1103", 2, null, 3f, "", 0, "C++", 1, null },
                    { "CSE-1104", 2, null, 1.5f, "", 0, "C++ Lab", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Contact", "CreditToBeTaken", "DepartmentId", "DesignationId", "Email", "Name", "RemainingCredit" },
                values: new object[,]
                {
                    { 1, "fjdsf", 123445L, 100.0, 2, 2, "saif@gmail.com", "Ezaz Raihan", 97.0 },
                    { 2, "adafsf", 12312445L, 100.0, 2, 1, "ashek@gmail.com", "Ashek", 70.0 }
                });
        }
    }
}
