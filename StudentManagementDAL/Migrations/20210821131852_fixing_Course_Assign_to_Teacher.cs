using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_Course_Assign_to_Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Courses_CourseCode_CourseDepartmentId",
                table: "CourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Departments_DepartmentId",
                table: "CourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Teachers_TeacherId",
                table: "CourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_CourseCode_CourseDepartmentId",
                table: "CourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_DepartmentId",
                table: "CourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_TeacherId",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "CourseDepartmentId",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "CourseAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "CourseAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CourseAssignments",
                type: "nvarchar(9)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseDepartmentId",
                table: "CourseAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseCode_CourseDepartmentId",
                table: "CourseAssignments",
                columns: new[] { "CourseCode", "CourseDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_DepartmentId",
                table: "CourseAssignments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_TeacherId",
                table: "CourseAssignments",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Courses_CourseCode_CourseDepartmentId",
                table: "CourseAssignments",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Departments_DepartmentId",
                table: "CourseAssignments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Teachers_TeacherId",
                table: "CourseAssignments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
