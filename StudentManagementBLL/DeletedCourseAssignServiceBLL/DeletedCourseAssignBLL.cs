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
            foreach (CourseAssignment assign in assignCourses)
            {
                Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Id == assign.CourseId);
                Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == assign.TeacherId);

                deletedCourseAssign.Id = assign.Id;
                deletedCourseAssign.CourseId = assign.CourseId;
                deletedCourseAssign.DepartmentId = assign.DepartmentId;
                deletedCourseAssign.TeacherId = assign.TeacherId;

                assign.IsAssigned = false;

                fetchingTeacher.CreditToBeTaken = fetchingTeacher.RemainingCredit;
                if (fetchingCourse != null)
                {
                    fetchingCourse.AssignTo = null;
                    fetchingCourse.TeacherId = null;
                    Context.Courses.Update(fetchingCourse);
                }
                Context.CourseAssignments.Remove(assign);
                Context.DeletedCourseAssigns.Add(deletedCourseAssign);
            }
            serviceResponse.Message = "Unassigned All Courses";
            serviceResponse.Success = true;
            Context.SaveChanges();
            return serviceResponse;
        }


    }
}