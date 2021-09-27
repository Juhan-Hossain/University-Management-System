using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseAssignBLL
{
    public class CourseAssignServiceBLL : Repository<CourseAssignment, ApplicationDbContext>, ICourseAssignServiceBLL
    {
        private readonly ApplicationDbContext Context;

        public CourseAssignServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }
        private void CreatingSingleCourseAssign(Teacher fetchingTeacher,Course fetchingCourse,CourseAssignment aCourseAssignment, ServiceResponse<CourseAssignment> serviceResponse, int departmentId)
        {
            fetchingCourse.AssignTo = fetchingTeacher.Name;
            fetchingCourse.TeacherId = fetchingTeacher.Id;

            aCourseAssignment.TeacherId = fetchingTeacher.Id;
            aCourseAssignment.DepartmentId = departmentId;
            aCourseAssignment.CourseId = fetchingCourse.Id;
            aCourseAssignment.IsAssigned = true;

            Context.CourseAssignments.Add(aCourseAssignment);
            serviceResponse.Data = aCourseAssignment;
            serviceResponse.Message = $"{fetchingTeacher.Name} will start taking {fetchingCourse.Code}" +
               $": {fetchingCourse.Name}";
        }
        //validates the fact of course assignment
        public virtual ServiceResponse<CourseAssignment> AssignCourseToTeacher(int departmentId, int teacherId, int courseId)
        {
            var serviceResponse = new ServiceResponse<CourseAssignment>();
            CourseAssignment aCourseAssignment = new CourseAssignment();
            try
            {
                Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Id == courseId);
                Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == teacherId);
                Department fetchingDepartment = Context.Departments.SingleOrDefault(x => x.Id == departmentId);
                serviceResponse.Data = Context.CourseAssignments.SingleOrDefault(x =>
                x.DepartmentId == fetchingDepartment.Id
                 && x.CourseId == fetchingCourse.Id);
                if (fetchingCourse.AssignTo !=null)
                {
                    serviceResponse.Message = $"this Course is already assigned to {fetchingCourse.AssignTo}";
                    serviceResponse.Success = false;
                }
                else if (serviceResponse.Data == null && serviceResponse.Success)
                {
                    if (fetchingTeacher.CreditToBeTaken >= fetchingCourse.Credit)
                    {
                        fetchingTeacher.CreditToBeTaken -= fetchingCourse.Credit;
                        CreatingSingleCourseAssign(fetchingTeacher,fetchingCourse,aCourseAssignment,serviceResponse,departmentId);
                    }
                    else
                    {

                        fetchingTeacher.CreditToBeTaken = 0;
                        CreatingSingleCourseAssign(fetchingTeacher, fetchingCourse, aCourseAssignment, serviceResponse, departmentId);
                    }
                }
                Context.SaveChanges();
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Error occured while assigning a teacher.";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

    }
}