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
        private readonly ApplicationDbContext Context;

        public CourseEnrollBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }
        public ServiceResponse<CourseEnroll> EnrollCourseToStudent(string sdtRegNo, string courseCode)
        {
            var serviceresponse = new ServiceResponse<CourseEnroll>();
            var astudentName = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Name;
            var acourseName = Context.Courses
                    .SingleOrDefault(x => x.Code == courseCode)
                    .Name;
            try
            {
                var aStudentId = Context.Students.SingleOrDefault(x => x.RegistrationNumber == sdtRegNo).Id;
                //----------------
                var aCourseId = Context.Courses.SingleOrDefault(x => x.Code == courseCode).Id;
                var acourseCode =courseCode;
                var aDepartmentId = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .DepartmentId;
                CourseEnroll acourseEnroll = new CourseEnroll();

                //------------
                serviceresponse.Data = Context.CourseEnrolls.SingleOrDefault(x =>
                x.EnrolledCourseId == aCourseId
                && x.EnrolledStudentId == aStudentId);

                if (acourseCode is null)
                {
                    serviceresponse.Message = "this Course does not exist.";
                    serviceresponse.Success = false;
                }
                else if (aStudentId is 0)
                {
                    serviceresponse.Message = "this aStudentRegNo does not exist.";
                    serviceresponse.Success = false;
                }

                else if (serviceresponse.Data == null)
                {
                    if (!serviceresponse.Success)
                    {
                        serviceresponse.Message = "Error occured while enrollment.";
                        serviceresponse.Success = false;
                    }
                    else
                    {
                        //----------
                        acourseEnroll.EnrolledCourseId = aCourseId;
                        acourseEnroll.Date = DateTime.Today;
                        acourseEnroll.IsEnrolled = true;
                        acourseEnroll.EnrolledStudentId = Context.Students
                            .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                            .Id;
                        acourseEnroll.StudentRegNo = sdtRegNo;
                        acourseEnroll.DepartmentId = aDepartmentId;
                        acourseEnroll.CourseCode = acourseCode;
                        Context.CourseEnrolls.Add(acourseEnroll);
                        Context.SaveChanges();
                        serviceresponse.Data = acourseEnroll;
                        serviceresponse.Success = true;

                        serviceresponse.Message = $"{acourseName} is successfully enrolled by {astudentName}";
                    }
                }
                else if (serviceresponse.Data.IsEnrolled)
                {
                    serviceresponse.Message = $"{astudentName} already enrolled in {acourseName}"; ;
                    serviceresponse.Success = false;
                }
            }
            catch (Exception ex)
            {
                serviceresponse.Message = $"{astudentName} already enrolled in {acourseName}";
                serviceresponse.Success = false;
            }
            return serviceresponse;
        }
    }
}