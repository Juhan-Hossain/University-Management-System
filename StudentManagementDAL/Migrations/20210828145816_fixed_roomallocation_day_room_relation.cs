using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixed_roomallocation_day_room_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_DayId",
                table: "RoomAllocationLists",
                column: "DayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_DayId",
                table: "RoomAllocationLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAllocationLists",
                table: "RoomAllocationLists",
                columns: new[] { "DayId", "RoomId" });
        }
    }
}
