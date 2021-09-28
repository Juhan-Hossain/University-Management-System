using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class removedKeyFromDeletedCOurseAssign01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletedCourseAssigns",
                table: "DeletedCourseAssigns",
                column: "Id");
            

            /* migrationBuilder.DropPrimaryKey(
                 name: "PK_DeletedCourseAssigns",
                 table: "DeletedCourseAssigns");*/

            migrationBuilder.AlterColumn<bool>(
                name: "IsAssigned",
                table: "DeletedCourseAssigns",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
                /*.OldAnnotation("SqlServer:Identity", "1, 1");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_RemainingCreditOfTeacher",
                table: "Teachers");
            migrationBuilder.AlterColumn<int>(
                name: "IsAssigned",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DeletedCourseAssigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
               /* .Annotation("SqlServer:Identity", "1, 1");*/

            
/*
            migrationBuilder.AddCheckConstraint(
                name: "CHK_RemainingCreditOfTeacher",
                table: "Teachers",
                sql: "RemainingCredit BETWEEN 0 AND CreditToBeTaken");*/
        }
    }
}
