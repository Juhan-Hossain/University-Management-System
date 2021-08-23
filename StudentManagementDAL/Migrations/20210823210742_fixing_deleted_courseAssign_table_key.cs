using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_deleted_courseAssign_table_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DeletedCourseAssigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DeletedCourseAssigns",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns",
                columns: new[] { "Code", "DepartmentId" });
        }
    }
}
