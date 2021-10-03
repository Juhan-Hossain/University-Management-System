using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DeletedCourseAssignServiceBLL
{
    public class DeletedCourseAssignBLL : Repository<DeletedCourseAssign, ApplicationDbContext>, IDeletedCourseAssignBLL
    {
        private readonly ApplicationDbContext Context;
        public DeletedCourseAssignBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }
        public ServiceResponse<DeletedCourseAssign> UnassignTeacher()
        {
            var serviceResponse = new ServiceResponse<DeletedCourseAssign>();
            var assignCourses = Context.CourseAssignments;
            DeletedCourseAssign deletedCourseAssign = new DeletedCourseAssign();
            //Execute Stored Procedure
            var x = _dbContext.Database.ExecuteSqlRaw("execute SpGetDeletedCourseAssignTable01");
          /*  var p = _dbContext.Database.ExecuteSqlRaw("EXEC SpViewRoomAllocation");
            var pp = Context.DeletedCourseAssigns.FromSqlRaw("select * from dbo.TempSchedule02").ToList();*/

            foreach (CourseAssignment assign in assignCourses)
            {
                Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Id == assign.CourseId);
                Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == assign.TeacherId);
                assign.IsAssigned = true;
                fetchingTeacher.RemainingCredit = fetchingTeacher.CreditToBeTaken;
                if (fetchingCourse != null)
                {
                    fetchingCourse.AssignTo = null;
                    fetchingCourse.TeacherId = null;
                    Context.Courses.Update(fetchingCourse);
                }
                Context.CourseAssignments.Remove(assign);
            }
            serviceResponse.Message = "Unassigned All Courses";
            serviceResponse.Success = true;
            Context.SaveChanges();
            return serviceResponse;
        }


    }
}