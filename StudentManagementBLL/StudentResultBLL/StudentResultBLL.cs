using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.StudentResultBLL
{
    public class StudentResultBLL : Repository<StudentResult, ApplicationDbContext>, IStudentResultBLL
    {
        private readonly ApplicationDbContext Context;

        public StudentResultBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }

        public override ServiceResponse<StudentResult> Add(StudentResult studentResult)
        {
            var serviceresponse = new ServiceResponse<StudentResult>();
            try
            {
                //fetching student with reg no
                string aStudentRegNo = Context.Students.SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo).RegistrationNumber;
                //fetching course with id
                var aCourseCode = Context.Courses.SingleOrDefault(x => x.Name == studentResult.CourseName).Code;
                //fetching student name with reg no
                string astudentName = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Name;

                //------------------------------------------------------------------

                string acourseName = Context.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName).Name;
                List<Course> courseList = new List<Course>();
                //get enrolled course list from GetEnrolledCoursesBystdRegNo()
                /*courseList = GetEnrolledCoursesBystdRegNo(studentResult.StudentRegNo).Data.ToList();*/

                //fetching departmentId with stdRegno
                int aDepartmentId = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .DepartmentId;
                //fetching departmentId with departmentId
                string aDepartmentName = Context.Departments.SingleOrDefault(x => x.Id == aDepartmentId).Name;

                StudentResult aResult = new StudentResult();

                //fetching departmentId with stdRegno
                string astudentEmail = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Email;

                //fetching data if there exist any or return null
                serviceresponse.Data = Context.StudentResults.SingleOrDefault(x =>
                x.CourseName == studentResult.CourseName
                && x.StudentRegNo == studentResult.StudentRegNo);

                if (studentResult.CourseName is null)
                {
                    serviceresponse.Message = "this Course does not exist.";
                    serviceresponse.Success = false;
                }
                else if (courseList is null)
                {
                    serviceresponse.Message = "this aStudentRegNo does not enrolled in any course.";
                    serviceresponse.Success = false;
                }
                else if (studentResult.StudentRegNo is null)
                {
                    serviceresponse.Message = "this aStudentRegNo does not exist.";
                    serviceresponse.Success = false;
                }

                //data does not exist so have to put it
                else if (serviceresponse.Data == null)
                {
                    //got error in the previous any case
                    if (!serviceresponse.Success)
                    {
                        serviceresponse.Message = "got any previous case error";
                        serviceresponse.Success = false;
                    }
                    else
                    {
                        try
                        {
                            //this block adding new student result
                            aResult.StudentRegNo = studentResult.StudentRegNo;

                            aResult.Name = astudentName;
                            aResult.CourseName = studentResult.CourseName;
                            aResult.Email = astudentEmail;
                            aResult.DepartmentName = aDepartmentName;
                            aResult.GradeLetter = studentResult.GradeLetter;
                            aResult.Result = true;





                            Context.StudentResults.Add(aResult);
                            Context.SaveChanges();
                            serviceresponse.Data = aResult;

                            serviceresponse.Success = true;

                            serviceresponse.Message = $"{astudentName}'s result of {acourseName} successfully added";
                        }
                        catch (Exception ex)
                        {
                            serviceresponse.Message = "Error occured while adding student result\n" +
                                ex.Message;
                            serviceresponse.Success = false;
                        }


                    }
                }

                else
                {
                    serviceresponse.Message = "this student have this course result";
                    serviceresponse.Success = false;



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

        //GetStudentResultByStudentRegNo:
        public ServiceResponse<IEnumerable<StudentResult>> GetResultBystdRegNo(string StudentRegNo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<StudentResult>>();
            try
            {
                var Results = new List<StudentResult>();
                List<Course> CourseList = new List<Course>();
                List<CourseEnroll> EnrolledCourseList = new List<CourseEnroll>();


                var aStudent = Context.Students
                  .SingleOrDefault(x => x.RegistrationNumber == StudentRegNo);
                var aStudentResult = Context.StudentResults.Where(x => x.StudentRegNo == StudentRegNo).ToList();
                //Taking list to load courselist of given student
                if (aStudentResult.Count > 0)
                {
                    serviceResponse.Data = aStudentResult;
                    serviceResponse.Message = "fetched student result successfully";
                }
                else
                {
                    serviceResponse.Message = "this student dont have any result yet! please add result";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching result.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}