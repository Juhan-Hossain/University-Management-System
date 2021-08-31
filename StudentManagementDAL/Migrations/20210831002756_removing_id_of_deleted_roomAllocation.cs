using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class removing_id_of_deleted_roomAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_deletedRoomAllocations",
                table: "deletedRoomAllocations");

            migrationBuilder.RenameTable(
                name: "deletedRoomAllocations",
                newName: "DeletedRoomAllocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletedRoomAllocations",
                table: "DeletedRoomAllocations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeletedRoomAllocations",
                table: "DeletedRoomAllocations");

            migrationBuilder.RenameTable(
                name: "DeletedRoomAllocations",
                newName: "deletedRoomAllocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deletedRoomAllocations",
                table: "deletedRoomAllocations",
                column: "Id");
        }
    }
}
