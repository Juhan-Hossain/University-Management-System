using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class addedsemester_end_points_and_populate_semester_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
