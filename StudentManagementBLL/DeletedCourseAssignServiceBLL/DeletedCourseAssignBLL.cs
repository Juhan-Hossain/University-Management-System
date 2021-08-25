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



        public ServiceResponse<DeletedCourseAssign> UnassignTeacher(bool flag)
        {
            var serviceResponse = new ServiceResponse<DeletedCourseAssign>();

            var assignCourses = Context.CourseAssignments;

            if (flag)
            {
                DeletedCourseAssign deletedCourseAssign = new DeletedCourseAssign();

                Context.CourseAssignments.FromSqlRaw<CourseAssignment>("SpGetDeletedCourseAssignTable01");

                foreach (CourseAssignment assign in assignCourses)
                {
                    Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Code == assign.Code);
                    Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == assign.TeacherId);
                    Department fetchingDepartment = Context.Departments.SingleOrDefault(x => x.Id == assign.DepartmentId);

                    deletedCourseAssign.Code = assign.Code;
                    deletedCourseAssign.CourseId = assign.CourseId;
                    deletedCourseAssign.DepartmentId = assign.DepartmentId;
                    deletedCourseAssign.TeacherId = assign.TeacherId;
                    assign.IsAssigned = 3;


                    fetchingTeacher.RemainingCredit += fetchingCourse.Credit;/*
                    fetchingTeacher.CreditToBeTaken -= fetchingCourse.Credit;*/

                    fetchingCourse.AssignTo = null;
                    fetchingCourse.TeacherId = null;

                    Context.Courses.Update(fetchingCourse);


                    Context.CourseAssignments.Update(assign);
                    Context.DeletedCourseAssigns.Add(deletedCourseAssign);

                }
                serviceResponse.Message = "Unassigned All Courses";
                serviceResponse.Success = true;
                Context.SaveChanges();


            }
            return serviceResponse;
        }


    }
}