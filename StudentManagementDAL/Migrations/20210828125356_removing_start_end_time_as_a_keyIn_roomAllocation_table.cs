using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class removing_start_end_time_as_a_keyIn_roomAllocation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists");

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
                columns: new[] { "DayId", "RoomId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists",
                columns: new[] { "DayId", "RoomId", "StartTime", "EndTime" });
        }
    }
}
