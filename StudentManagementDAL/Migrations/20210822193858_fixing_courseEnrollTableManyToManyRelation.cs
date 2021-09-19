using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_courseEnrollTableManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Students_StudentId",
                table: "CourseEnrolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseEnrolls");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseEnrolls",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrolls_StudentId",
                table: "CourseEnrolls",
                newName: "IX_CourseEnrolls_DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentRegNo",
                table: "CourseEnrolls",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CourseEnrolls",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnrolledCourseId",
                table: "CourseEnrolls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnrolledStudentId",
                table: "CourseEnrolls",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls",
                columns: new[] { "StudentRegNo", "CourseCode", "DepartmentId" });

           /* migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    CoursesCode = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    CoursesDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.StudentsId, x.CoursesCode, x.CoursesDepartmentId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesCode_CoursesDepartmentId",
                        columns: x => new { x.CoursesCode, x.CoursesDepartmentId },
                        principalTable: "Courses",
                        principalColumns: new[] { "Code", "DepartmentId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseCode_DepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_EnrolledStudentId",
                table: "CourseEnrolls",
                column: "EnrolledStudentId");

           /* migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CoursesCode_CoursesDepartmentId",
                table: "CourseStudent",
                columns: new[] { "CoursesCode", "CoursesDepartmentId" });*/

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_DepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "DepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Departments_DepartmentId",
                table: "CourseEnrolls",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Students_EnrolledStudentId",
                table: "CourseEnrolls",
                column: "EnrolledStudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Departments_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Students_EnrolledStudentId",
                table: "CourseEnrolls");

           /* migrationBuilder.DropTable(
                name: "CourseStudent");*/

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseCode_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_EnrolledStudentId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "EnrolledCourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "EnrolledStudentId",
                table: "CourseEnrolls");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "CourseEnrolls",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrolls_DepartmentId",
                table: "CourseEnrolls",
                newName: "IX_CourseEnrolls_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentRegNo",
                table: "CourseEnrolls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseEnrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Students_StudentId",
                table: "CourseEnrolls",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
