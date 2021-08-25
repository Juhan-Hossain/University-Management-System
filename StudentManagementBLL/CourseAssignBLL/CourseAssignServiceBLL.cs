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
        //validates the fact of course assignment
        public virtual ServiceResponse<CourseAssignment> AssignCourseToTeacher(int departmentId, string CourseCode, int teacherId)
        {
            var serviceResponse = new ServiceResponse<CourseAssignment>();

            Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Code == CourseCode);
            Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == teacherId);
            Department fetchingDepartment = Context.Departments.SingleOrDefault(x => x.Id == departmentId);
            serviceResponse.Data = Context.CourseAssignments.SingleOrDefault(x =>
            x.DepartmentId == fetchingDepartment.Id
            && x.TeacherId == fetchingTeacher.Id
             && x.Code != fetchingCourse.Code);
            
            if (fetchingCourse is null)
            {
                serviceResponse.Message = "this Course does not exist.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (fetchingTeacher is null)
            {
                serviceResponse.Message = "this Teacher does not exist.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (fetchingDepartment is null)
            {
                serviceResponse.Message = "this Department does not exist.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (serviceResponse.Data == null)
            {
                CourseAssignment aCourseAssignment = new CourseAssignment();
               
                if (fetchingTeacher.RemainingCredit - fetchingCourse.Credit >= 0 && fetchingCourse.TeacherId == null)
                {
                    try
                    {
                        fetchingTeacher.RemainingCredit -= fetchingCourse.Credit;

                        fetchingCourse.AssignTo = fetchingTeacher.Name;
                        fetchingCourse.TeacherId = fetchingTeacher.Id;

                        aCourseAssignment.TeacherId = fetchingTeacher.Id;
                        aCourseAssignment.DepartmentId = fetchingDepartment.Id;
                        aCourseAssignment.CourseId = fetchingCourse.Id;
                        aCourseAssignment.IsAssigned = 2;
                        aCourseAssignment.Code = fetchingCourse.Code;
                        var p = Context.CourseAssignments
                            .Any(x => x.Code == fetchingCourse.Code && x.IsAssigned == 2);
                        if (!p)
                        {
                            Context.CourseAssignments.Add(aCourseAssignment);
                            serviceResponse.Data = aCourseAssignment;

                            serviceResponse.Message = $"{fetchingTeacher.Name} will start taking {fetchingCourse.Code}" +
                               $": {fetchingCourse.Name}";
                        }
                        else
                        {

                            serviceResponse.Message = "course already assigned to a teacher";
                            serviceResponse.Success = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        serviceResponse.Message = "Error occured while creating course assign \n" +
                            "remaining credit>=course credit" + ex.Message;
                        serviceResponse.Success = false;
                    }
                    Context.SaveChanges();
                    return serviceResponse;

                }

                /*//need to be redirect this call
                serviceResponse.Message = $"{fetchingTeacher.Name} does not have Remaining" +
                $" Credit to take {fetchingCourse.Code}: {fetchingCourse.Name}";
                serviceResponse.Success = false;
                _dbContext.SaveChanges();
                return serviceResponse;*/
            }



            else
            {
                serviceResponse.Message = "error occured while adding to course assign table";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}