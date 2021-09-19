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
            try
            {
                var aStudentRegNo = Context.Students.SingleOrDefault(x => x.RegistrationNumber == sdtRegNo).ToString();
                //----------------
                var aCourseId = Context.Courses.SingleOrDefault(x => x.Code == courseCode).Id;
                var astudentName = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Name;
                var acourseName = Context.Courses
                    .SingleOrDefault(x => x.Code == courseCode)
                    .Name;
                var acourseCode =courseCode;
                var aDepartmentId = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .DepartmentId;
                CourseEnroll acourseEnroll = new CourseEnroll();

                //------------
                serviceresponse.Data = Context.CourseEnrolls.SingleOrDefault(x =>
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
                    //------------------------------
                    acourseEnroll.EnrolledCourseId = aCourseId;
                    acourseEnroll.Date = DateTime.Today;
                    acourseEnroll.IsEnrolled = true;
                    acourseEnroll.EnrolledStudentId = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == sdtRegNo)
                        .Id;
                    acourseEnroll.StudentRegNo = sdtRegNo;
                    acourseEnroll.DepartmentId = aDepartmentId;

                    acourseEnroll.CourseCode = acourseCode;


                    Context.CourseEnrolls.Update(acourseEnroll);

                    Context.SaveChanges();
                    serviceresponse.Data = acourseEnroll;
                    serviceresponse.Message = "Course Enrollment Updated";
                }

            }
            catch (Exception ex)
            {
                serviceresponse.Message = "student already enrolled in this course" +
                    ex.Message;
                serviceresponse.Success = false;
            }
            return serviceresponse;
        }
    }
}