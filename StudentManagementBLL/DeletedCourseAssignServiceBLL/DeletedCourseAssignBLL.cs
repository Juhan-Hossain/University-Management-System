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

            var assignCourses = _dbContext.CourseAssignments;

            if (flag)
            {
                DeletedCourseAssign deletedCourseAssign = new DeletedCourseAssign();
                





                foreach (CourseAssignment assign in assignCourses)
                {
                    var fetchingCourse = _dbContext.Courses.SingleOrDefault(x => x.Code == assign.Code);
                    var fetchingTeacher = _dbContext.Teachers.SingleOrDefault(x => x.Id == assign.TeacherId);
                    var fetchingDepartment = _dbContext.Departments.SingleOrDefault(x => x.Id == assign.DepartmentId);

                   


                    deletedCourseAssign.Code = assign.Code;
                    deletedCourseAssign.CourseId = assign.CourseId;
                    deletedCourseAssign.DepartmentId = assign.DepartmentId;
                    deletedCourseAssign.TeacherId = assign.TeacherId;


                    assign.IsAssigned = 3;

                    fetchingTeacher.RemainingCredit += fetchingCourse.Credit;
                    fetchingTeacher.CreditToBeTaken -= fetchingCourse.Credit;

                    _dbContext.DeletedCourseAssigns.Add(deletedCourseAssign);
                    serviceResponse.Message = "Unassigned All Courses";
                    serviceResponse.Success = true;


                }
            }
            return serviceResponse;
        }


    }
}