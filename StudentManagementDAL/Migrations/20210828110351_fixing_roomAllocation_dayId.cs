using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_roomAllocation_dayId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_weekDays_WeekDayId",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_WeekDayId",
                table: "RoomAllocationLists");

            migrationBuilder.DropColumn(
                name: "WeekDayId",
                table: "RoomAllocationLists");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_weekDays_DayId",
                table: "RoomAllocationLists",
                column: "DayId",
                principalTable: "weekDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_weekDays_DayId",
                table: "RoomAllocationLists");

            migrationBuilder.AddColumn<int>(
                name: "WeekDayId",
                table: "RoomAllocationLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_WeekDayId",
                table: "RoomAllocationLists",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_weekDays_WeekDayId",
                table: "RoomAllocationLists",
                column: "WeekDayId",
                principalTable: "weekDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
