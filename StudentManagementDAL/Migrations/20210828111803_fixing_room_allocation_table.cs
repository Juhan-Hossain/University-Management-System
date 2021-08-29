using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_room_allocation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocationLists",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists",
                columns: new[] { "CourseCode", "DepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocationLists",
                type: "nvarchar(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists",
                columns: new[] { "CourseCode", "DepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
