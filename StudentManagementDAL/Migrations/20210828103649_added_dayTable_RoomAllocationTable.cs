using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class added_dayTable_RoomAllocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations");*/

           /* migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Departments_DepartmentId",
                table: "RoomAllocations");*/

           /* migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Rooms_RoomId",
                table: "RoomAllocations");*/

           /* migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_CourseCode_CourseDepartmentId",
                table: "RoomAllocations");*/

           /* migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_DepartmentId",
                table: "RoomAllocations");*/

            /*migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_RoomId",
                table: "RoomAllocations");*/

            /*migrationBuilder.DropColumn(
                name: "Day",
                table: "RoomAllocations");*/

           /* migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "RoomAllocations",
                newName: "DayId");*/

           /* migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "RoomAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);*/

           /* migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldNullable: true);*/

            /*migrationBuilder.AddColumn<string>(
                name: "CourseCode1",
                table: "RoomAllocations",
                type: "nvarchar(9)",
                nullable: true);*/

            migrationBuilder.CreateTable(
                name: "weekDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weekDays", x => x.Id);
                });

           /* migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_CourseCode1_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode1", "CourseDepartmentId" });*/

           /* migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode1_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode1", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode1_CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.DropTable(
                name: "weekDays");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_CourseCode1_CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.DropColumn(
                name: "CourseCode1",
                table: "RoomAllocations");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "RoomAllocations",
                newName: "DeptId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "RoomAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocations",
                type: "nvarchar(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "RoomAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_CourseCode_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode", "CourseDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_DepartmentId",
                table: "RoomAllocations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_RoomId",
                table: "RoomAllocations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Departments_DepartmentId",
                table: "RoomAllocations",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Rooms_RoomId",
                table: "RoomAllocations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
