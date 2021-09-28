using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class addedPrimaryKeyForDeletedCourseAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                /*.Annotation("SqlServer:Identity", "1, 1");*/

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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
              /*  .OldAnnotation("SqlServer:Identity", "1, 1");*/
        }
    }
}
