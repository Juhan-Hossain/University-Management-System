using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class removedRemainingCreditFromCOurseAssignAndDeletedCourseAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RemainingCredit",
                table: "Teachers",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                /*.Annotation("SqlServer:Identity", "1, 1");*/

            migrationBuilder.AlterColumn<bool>(
                name: "IsAssigned",
                table: "CourseAssignments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<double>(
                name: "RemainingCredit",
                table: "Teachers",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
             /*   .OldAnnotation("SqlServer:Identity", "1, 1");*/

            migrationBuilder.AlterColumn<int>(
                name: "IsAssigned",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
