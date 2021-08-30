using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class populating_room_allocation_table_andWeekday_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "RoomAllocationLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "RoomAllocationLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocationLists",
                type: "nvarchar(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeekDayId",
                table: "RoomAllocationLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists",
                columns: new[] { "DayId", "RoomId", "StartTime", "EndTime" });

            migrationBuilder.InsertData(
                table: "weekDays",
                columns: new[] { "Id", "DayName" },
                values: new object[,]
                {
                    { 1, "Saturday" },
                    { 2, "Sunday" },
                    { 3, "Monday" },
                    { 4, "Tuesday" },
                    { 5, "Wednessday" },
                    { 6, "Thursday" },
                    { 7, "Friday" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_CourseCode_DepartmentId",
                table: "RoomAllocationLists",
                columns: new[] { "CourseCode", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_DepartmentId",
                table: "RoomAllocationLists",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_RoomId",
                table: "RoomAllocationLists",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_WeekDayId",
                table: "RoomAllocationLists",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists",
                columns: new[] { "CourseCode", "DepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Departments_DepartmentId",
                table: "RoomAllocationLists",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Rooms_RoomId",
                table: "RoomAllocationLists",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_weekDays_WeekDayId",
                table: "RoomAllocationLists",
                column: "WeekDayId",
                principalTable: "weekDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Departments_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Rooms_RoomId",
                table: "RoomAllocationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_weekDays_WeekDayId",
                table: "RoomAllocationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_CourseCode_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_RoomId",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_WeekDayId",
                table: "RoomAllocationLists");

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "weekDays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "WeekDayId",
                table: "RoomAllocationLists");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocationLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "RoomAllocationLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "RoomAllocationLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists",
                column: "Id");
        }
    }
}
