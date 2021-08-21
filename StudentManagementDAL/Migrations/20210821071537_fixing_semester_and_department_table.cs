using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_semester_and_department_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Courses_CourseId",
                table: "CourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Courses_CourseId",
                table: "RoomAllocations");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_CourseId",
                table: "RoomAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseId",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_CourseId",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Semesters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "RoomAllocations",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CourseDepartmentId",
                table: "RoomAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "Code",
                table: "Courses",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CourseEnrolls",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CourseDepartmentId",
                table: "CourseEnrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                columns: new[] { "Code", "DepartmentId" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "AssignTo", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[] { "CSE-1102", 2, null, 3f, "", "C Lab", 1, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "AssignTo", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[] { "CSE-1103", 2, null, 3f, "", "C++", 1, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "DepartmentId", "AssignTo", "Credit", "Description", "Name", "SemesterId", "TeacherId" },
                values: new object[] { "CSE-1104", 2, null, 1.5f, "", "C++ Lab", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_Id",
                table: "Semesters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_Name",
                table: "Semesters",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_CourseCode_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode", "CourseDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Code",
                table: "Courses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_LengthOfCodeOfCourse",
                table: "Courses",
                sql: "LEN(Code) >= 5");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CreditRangeOfCourse",
                table: "Courses",
                sql: "Credit BETWEEN 0.5 AND 5.0");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "CourseDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseCode_CourseDepartmentId",
                table: "CourseAssignments",
                columns: new[] { "CourseCode", "CourseDepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Courses_CourseCode_CourseDepartmentId",
                table: "CourseAssignments",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations",
                columns: new[] { "CourseCode", "CourseDepartmentId" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Courses_CourseCode_CourseDepartmentId",
                table: "CourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAllocations_Courses_CourseCode_CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_Id",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_Name",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_RoomAllocations_CourseCode_CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Code",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Name",
                table: "Courses");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_LengthOfCodeOfCourse",
                table: "Courses");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CreditRangeOfCourse",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrolls_CourseCode_CourseDepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_CourseCode_CourseDepartmentId",
                table: "CourseAssignments");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-1102", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-1103", 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumns: new[] { "Code", "DepartmentId" },
                keyValues: new object[] { "CSE-1104", 2 });

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "RoomAllocations");

            migrationBuilder.DropColumn(
                name: "CourseDepartmentId",
                table: "RoomAllocations");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseDepartmentId",
                table: "CourseEnrolls");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "CourseDepartmentId",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Semesters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllocations_CourseId",
                table: "RoomAllocations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolls_CourseId",
                table: "CourseEnrolls",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseId",
                table: "CourseAssignments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Courses_CourseId",
                table: "CourseAssignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrolls_Courses_CourseId",
                table: "CourseEnrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAllocations_Courses_CourseId",
                table: "RoomAllocations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
