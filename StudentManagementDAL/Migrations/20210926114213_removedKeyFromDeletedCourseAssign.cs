using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class removedKeyFromDeletedCourseAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeletedCourseAssigns");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DeletedCourseAssigns");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DeletedCourseAssigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns",
                column: "Id");
        }
    }
}
