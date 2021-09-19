using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class addIdAsPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Departments_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCode_CoursesDepartmentId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_CourseCode_DepartmentId",
                table: "RoomAllocationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_CoursesCode_CoursesDepartmentId",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseCode_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CoursesCode",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "CoursesDepartmentId",
                table: "CourseStudent",
                newName: "CoursesId");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocationLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "RoomAllocationLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "CourseEnrolls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "CourseEnrolls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)");

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
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_CourseId",
                table: "RoomAllocationLists",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseId",
                table: "CourseEnrolls",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseId",
                table: "CourseEnrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Departments_DepartmentId",
                table: "CourseEnrolls",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                table: "CourseStudent",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseId",
                table: "RoomAllocationLists",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Departments_DepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseId",
                table: "RoomAllocationLists");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocationLists_CourseId",
                table: "RoomAllocationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "RoomAllocationLists");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseEnrolls");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseStudent",
                newName: "CoursesDepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "RoomAllocationLists",
                type: "nvarchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CoursesCode",
                table: "CourseStudent",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentRegNo",
                table: "CourseEnrolls",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "CourseEnrolls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "CourseEnrolls",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "StudentsId", "CoursesCode", "CoursesDepartmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                columns: new[] { "Code", "DepartmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrolls",
                table: "CourseEnrolls",
                columns: new[] { "StudentRegNo", "CourseCode", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocationLists_CourseCode_DepartmentId",
                table: "RoomAllocationLists",
                columns: new[] { "CourseCode", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CoursesCode_CoursesDepartmentId",
                table: "CourseStudent",
                columns: new[] { "CoursesCode", "CoursesDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseCode_DepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "DepartmentId" });

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
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCode_CoursesDepartmentId",
                table: "CourseStudent",
                columns: new[] { "CoursesCode", "CoursesDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocationLists_Courses_CourseCode_DepartmentId",
                table: "RoomAllocationLists",
                columns: new[] { "CourseCode", "DepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
