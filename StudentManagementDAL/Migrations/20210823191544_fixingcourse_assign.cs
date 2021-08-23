using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixingcourse_assign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "RoomAllocations");

            migrationBuilder.AlterColumn<int>(
                name: "CourseDepartmentId",
                table: "RoomAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocations",
                type: "nvarchar(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.AlterColumn<int>(
                name: "CourseDepartmentId",
                table: "RoomAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocations",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "RoomAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
