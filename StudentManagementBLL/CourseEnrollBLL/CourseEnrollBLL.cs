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
                var acourseCode = _dbContext.Courses
                    .SingleOrDefault(x => x.Name == courseName).Code;
                var aDepartmentId = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .DepartmentId;
                CourseEnroll acourseEnroll = new CourseEnroll();


                serviceresponse.Data = _dbContext.CourseEnrolls.SingleOrDefault(x =>
                x.EnrolledCourseId == aCourseId
                && x.StudentRegNo == aStudentRegNo);

                if (acourseCode is null)
                {
                    serviceresponse.Message = "this Course does not exist.";
                    serviceresponse.Success = false;
                }
                else if (aStudentRegNo is null)
                {
                    serviceresponse.Message = "this aStudentRegNo does not exist.";
                    serviceresponse.Success = false;
                }

                else if (serviceresponse.Data == null)
                {
                    if (!serviceresponse.Success)
                    {
                        serviceresponse.Message = "Course is already assigned.";
                        serviceresponse.Success = false;
                    }
                    else
                    {
                        acourseEnroll.EnrolledCourseId = aCourseId;
                        acourseEnroll.Date = DateTime.Today;
                        acourseEnroll.IsEnrolled = true;
                        acourseEnroll.EnrolledStudentId = _dbContext.Students
                            .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                            .Id;
                        acourseEnroll.StudentRegNo = sdtRegNo;
                        acourseEnroll.DepartmentId = aDepartmentId;

                        acourseEnroll.CourseCode = acourseCode;


                        _dbContext.CourseEnrolls.Add(acourseEnroll);
                        _dbContext.SaveChanges();
                        serviceresponse.Data = acourseEnroll;
                        serviceresponse.Success = true;

                        serviceresponse.Message = $"{astudentName} will start taking {acourseName}";
                    }
                }
                else if (serviceresponse.Data.IsEnrolled)
                {
                    serviceresponse.Message = "Course is already Enrolled";
                    serviceresponse.Success = false;
                }
                else
                {

                    acourseEnroll.EnrolledCourseId = aCourseId;
                    acourseEnroll.Date = DateTime.Today;
                    acourseEnroll.IsEnrolled = true;
                    acourseEnroll.EnrolledStudentId = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Id;
                    acourseEnroll.StudentRegNo = sdtRegNo;
                    acourseEnroll.DepartmentId = aDepartmentId;

                    acourseEnroll.CourseCode = acourseCode;


                    _dbContext.CourseEnrolls.Update(acourseEnroll);
                    _dbContext.SaveChanges();
                    serviceresponse.Data = acourseEnroll;
                    serviceresponse.Message = "Course Enrollment Updated";
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
