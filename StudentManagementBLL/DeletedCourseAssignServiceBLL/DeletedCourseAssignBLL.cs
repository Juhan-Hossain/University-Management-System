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

        public DeletedCourseAssignBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }



        public ServiceResponse<DeletedCourseAssign> UnassignTeacher(bool flag)
        {
            var serviceResponse = new ServiceResponse<DeletedCourseAssign>();

            var courses = _dbContext.CourseAssignments;
            if (flag)
            {
                DeletedCourseAssign courseAssign = new DeletedCourseAssign();

                foreach (CourseAssignment assign in courses)
                {
                    var fetchingCourse = _dbContext.Courses.SingleOrDefault(x => x.Code == assign.Code);
                    var fetchingTeacher = _dbContext.Teachers.SingleOrDefault(x => x.Id == assign.TeacherId);
                    var fetchingDepartment = _dbContext.Departments.SingleOrDefault(x => x.Id == assign.DepartmentId);

                    courseAssign.Code = assign.Code;
                    courseAssign.CourseId = assign.CourseId;
                    courseAssign.DepartmentId = assign.DepartmentId;
                    courseAssign.TeacherId = assign.TeacherId;


                    assign.IsAssigned = 3;

                    fetchingTeacher.RemainingCredit += fetchingCourse.Credit;
                    fetchingTeacher.CreditToBeTaken -= fetchingCourse.Credit;

                    _dbContext.DeletedCourseAssigns.Add(courseAssign);
                    serviceResponse.Message = "Unassigned All Courses";
                    serviceResponse.Success = true;


                }
            }
            return serviceResponse;
        }


    }
}