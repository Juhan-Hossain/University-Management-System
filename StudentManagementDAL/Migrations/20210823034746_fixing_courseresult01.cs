using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class fixing_courseresult01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentRegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GradeLetter = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentResult_StudentGrades_GradeLetter",
                        column: x => x.GradeLetter,
                        principalTable: "StudentGrades",
                        principalColumn: "Grade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_CourseName_StudentRegNo",
                table: "StudentResult",
                columns: new[] { "CourseName", "StudentRegNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_GradeLetter",
                table: "StudentResult",
                column: "GradeLetter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentResult");
        }
    }
}
