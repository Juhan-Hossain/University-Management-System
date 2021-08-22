using Microsoft.EntityFrameworkCore;

using RepositoryLayer;

using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseEnrollBLL
{
    public class CourseEnrollBLL : Repository<CourseEnroll, ApplicationDbContext>, ICourseEnrollBLL
    {
        public CourseEnrollBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public ServiceResponse<CourseEnroll> EnrollCourseToStudent(string sdtRegNo, string courseName)
        {
            var serviceresponse = new ServiceResponse<CourseEnroll>();
            try
            {
                var aStudentRegNo = _dbContext.Students.SingleOrDefault(x => x.RegistrationNumber == sdtRegNo).ToString();
                var aCourseId = _dbContext.Courses.SingleOrDefault(x => x.Name == courseName).Id;
                var astudentName = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Name;
                var acourseName = _dbContext.Courses
                    .SingleOrDefault(x => x.Name == courseName)
                    .Name;
                CourseEnroll acourseEnroll = new CourseEnroll();


                serviceresponse.Data = _dbContext.CourseEnrolls.SingleOrDefault(x =>
                x.CourseId == aCourseId
                && x.StudentRegNo == aStudentRegNo);



                if (serviceresponse.Data == null)
                {


                    serviceresponse.Data.CourseId = aCourseId;
                    serviceresponse.Data.Date = DateTime.Today;
                    serviceresponse.Data.IsEnrolled = true;
                    serviceresponse.Data.StudentId = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Id;
                    serviceresponse.Data.StudentRegNo = aStudentRegNo;

                    _dbContext.CourseEnrolls.Add(serviceresponse.Data);
                    _dbContext.SaveChanges();

                    serviceresponse.Success = true;

                    serviceresponse.Message = $"{astudentName} will start taking {acourseName}";
                }
                



                else if (serviceresponse.Data.IsEnrolled)
                {
                    serviceresponse.Message = "Course is already Enrolled";
                    serviceresponse.Success = false;
                }
                else
                {

                    serviceresponse.Data.CourseId = aCourseId;
                    serviceresponse.Data.Date = DateTime.Today;
                    serviceresponse.Data.IsEnrolled = true;
                    serviceresponse.Data.StudentId = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Id;
                    serviceresponse.Data.StudentRegNo = aStudentRegNo;


                    _dbContext.CourseEnrolls.Update(serviceresponse.Data);
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                serviceresponse.Message = "Error occured when fetching data from course enroll table" +
                    ex.Message;
                serviceresponse.Success = false;
            }
            return serviceresponse;
        }
    }
}
