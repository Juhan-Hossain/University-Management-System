using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class SpGetDeletedRoomAllocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @" CREATE PROCEDURE SpGetDeletedRoomAllocationTable
                                AS
                                BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO [StudentManagementRuetLatest].[dbo].[deletedRoomAllocations] (CourseCode,DepartmentId,RoomId,DayId,StartTime,EndTime,FromMeridiem,ToMeridiem)
    (SELECT CourseCode,DepartmentId,RoomId,DayId,StartTime,EndTime,FromMeridiem,ToMeridiem FROM [StudentManagementRuetLatest].[dbo].[RoomAllocationLists])
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @" DROP PROCEDURE SpGetDeletedRoomAllocationTable";
            migrationBuilder.Sql(procedure);
        }
    }
}
