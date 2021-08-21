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
    public class CourseAssignServiceBLL:Repository<CourseAssignment,ApplicationDbContext>,ICourseAssignServiceBLL
    {
        public CourseAssignServiceBLL(ApplicationDbContext dbContext):base(dbContext) 
        {

        }
        //validates the fact of course assignment
        public virtual ServiceResponse<CourseAssignment> GetByCompositeKey(int departmentId, int cid, int teacherId)
        {
            var serviceResponse = new ServiceResponse<CourseAssignment>();
            try
            {
                serviceResponse.Data = _dbContext.CourseAssignments.FirstOrDefault(x =>
                x.DepartmentId == departmentId
                && x.TeacherId != teacherId
                 && x.CourseId != cid);                   

                    if (serviceResponse.Data == null && serviceResponse.Data.IsAssigned)
                    {
                        serviceResponse.Message = "Course is already assigned.";
                        serviceResponse.Success = false;
                    }
                    else
                    {
                        //Checking remaining credit
                        Teacher aTeacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == teacherId);
                        Course aCourse = _dbContext.Courses.FirstOrDefault(c => c.Id == cid);
                        CourseAssignment aCourseAssignment = new CourseAssignment();
                        if (aTeacher.RemainingCredit >= aCourse.Credit)
                        {
                            aTeacher.RemainingCredit -= aCourse.Credit;
                            aTeacher.CreditToBeTaken += aCourse.Credit;

                        aCourse.AssignTo = aTeacher.Name;
                        aCourse.TeacherId = aTeacher.Id;

                        aCourseAssignment.TeacherId = teacherId;
                        aCourseAssignment.DepartmentId = departmentId;
                        aCourseAssignment.CourseId = cid;
                        aCourseAssignment.IsAssigned = true;
                        aCourseAssignment.Code = aCourse.Code;


                        _dbContext.CourseAssignments.Add(aCourseAssignment);
                         serviceResponse.Message = $"{aTeacher.Name} will start taking {aCourse.Code}: {aCourse.Name}";
                        }
                        else
                        {
                            serviceResponse.Message = $"{aTeacher.Name} does not have Remaining Credit to take {aCourse.Code}: {aCourse.Name}";
                            serviceResponse.Success = false;
                        }

                    }
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
