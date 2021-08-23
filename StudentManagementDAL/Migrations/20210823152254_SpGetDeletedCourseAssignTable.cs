using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class SpGetDeletedCourseAssignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @" CREATE PROCEDURE SpGetDeletedCourseAssignTable
                                AS
                                BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO [StudentManagementRuetLatest].[dbo].[DeletedCourseAssigns] (DepartmentId, Code, TeacherId, CourseId)
    (SELECT DepartmentId, Code, TeacherId, CourseId,IsAssigned FROM [StudentManagementRuetLatest].[dbo].[CourseAssignments])
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @" DROP PROCEDURE SpGetDeletedCourseAssignTable";
            migrationBuilder.Sql(procedure);
        }
    }
}
