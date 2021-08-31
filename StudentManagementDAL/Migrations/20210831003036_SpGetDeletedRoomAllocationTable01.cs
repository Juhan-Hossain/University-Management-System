using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementDAL.Migrations
{
    public partial class SpGetDeletedRoomAllocationTable01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"USE [StudentManagementRuetLatest]
GO
/****** Object:  StoredProcedure [dbo].[SpGetDeletedRoomAllocationTable01]    Script Date: 8/31/2021 6:46:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 ALTER PROCEDURE [dbo].[SpGetDeletedRoomAllocationTable01]
                                AS
                                BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO [StudentManagementRuetLatest].[dbo].[DeletedRoomAllocations] (CourseCode,DepartmentId,RoomId,DayId,StartTime,EndTime,FromMeridiem,ToMeridiem)
    (SELECT CourseCode,DepartmentId,RoomId,DayId,StartTime,EndTime,FromMeridiem,ToMeridiem FROM [StudentManagementRuetLatest].[dbo].[RoomAllocationLists])
                                END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @" DROP PROCEDURE SpGetDeletedRoomAllocationTable01";
            migrationBuilder.Sql(procedure);
        }
    }
}
