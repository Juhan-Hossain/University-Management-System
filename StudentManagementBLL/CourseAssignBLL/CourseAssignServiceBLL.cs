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
        public CourseAssignServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        //validates the fact of course assignment
        public virtual ServiceResponse<CourseAssignment> AssignCourseToTeacher(int departmentId, string CourseCode, int teacherId)
        {
            var serviceResponse = new ServiceResponse<CourseAssignment>();
            try
            {
                var fetchingCourse = _dbContext.Courses.SingleOrDefault(x => x.Code == CourseCode);
                var fetchingTeacher = _dbContext.Teachers.SingleOrDefault(x => x.Id == teacherId);
                var fetchingDepartment = _dbContext.Departments.SingleOrDefault(x => x.Id == departmentId);
                serviceResponse.Data = _dbContext.CourseAssignments.SingleOrDefault(x =>
                x.DepartmentId == fetchingDepartment.Id
                && x.TeacherId == fetchingTeacher.Id
                 && x.Code != fetchingCourse.Code);


                if (fetchingCourse is null)
                {
                    serviceResponse.Message = "this Course does not exist.";
                    serviceResponse.Success = false;
                }
                else if (fetchingTeacher is null)
                {
                    serviceResponse.Message = "this Teacher does not exist.";
                    serviceResponse.Success = false;
                }
                else if (fetchingDepartment is null)
                {
                    serviceResponse.Message = "this Department does not exist.";
                    serviceResponse.Success = false;
                }
                else if (serviceResponse.Data == null)
                {
                    if (!serviceResponse.Success)
                    {
                        serviceResponse.Message = "Course is already assigned.";
                        serviceResponse.Success = false;
                    }
                    else
                    {

                        CourseAssignment aCourseAssignment = new CourseAssignment();
                        if (fetchingTeacher.RemainingCredit >= fetchingCourse.Credit)
                        {
                            fetchingTeacher.RemainingCredit -= fetchingCourse.Credit;
                            fetchingTeacher.CreditToBeTaken += fetchingCourse.Credit;

                            fetchingCourse.AssignTo = fetchingTeacher.Name;
                            fetchingCourse.TeacherId = fetchingTeacher.Id;

                            aCourseAssignment.TeacherId = teacherId;
                            aCourseAssignment.DepartmentId = departmentId;
                            aCourseAssignment.CourseId = fetchingCourse.Id;
                            aCourseAssignment.IsAssigned = 2;
                            aCourseAssignment.Code = CourseCode;


                            _dbContext.CourseAssignments.Add(aCourseAssignment);
                            _dbContext.SaveChanges();
                            serviceResponse.Data = aCourseAssignment;
                            /*serviceResponse.Success = true;*/

                            serviceResponse.Message = $"{fetchingTeacher.Name} will start taking {fetchingCourse.Code}" +
                               $": {fetchingCourse.Name}";
                        }
                        else
                        {
                            serviceResponse.Message = $"{fetchingTeacher.Name} does not have Remaining" +
                            $" Credit to take {fetchingCourse.Code}: {fetchingCourse.Name}";
                            serviceResponse.Success = false;
                        }
                    }

                }
                else if (serviceResponse.Data.IsAssigned==1 || serviceResponse.Data.IsAssigned == 3)
                {
                    serviceResponse.Message = "Course is already assigned";
                    serviceResponse.Success = false;
                }
                else
                {

                    serviceResponse.Data.IsAssigned = 2;
                    serviceResponse.Data.DepartmentId = departmentId;
                    serviceResponse.Data.CourseId = fetchingCourse.Id;

                    serviceResponse.Data.Code = CourseCode;

                    _dbContext.CourseAssignments.Update(serviceResponse.Data);
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public virtual void UnassignTeacher(bool flag)
        {
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



                }
            }


        }
    }
}
