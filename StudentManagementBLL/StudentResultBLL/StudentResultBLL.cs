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
        public StudentResultBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override ServiceResponse<StudentResult> Add(StudentResult studentResult)
        {
            var serviceresponse = new ServiceResponse<StudentResult>();
            try
            {
                var aStudentRegNo = _dbContext.Students.SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo).ToString();
                var aCourseId = _dbContext.Courses.SingleOrDefault(x => x.Name == studentResult.CourseName).Id;
                var astudentName = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Name;
                var acourseName = _dbContext.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName)
                    .Name;
                //------------------------------------------------------------------
                /*var acourseCode = _dbContext.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName).Code;*/
                var courseList = new List<Course>();
                courseList = (List<Course>)GetEnrolledCoursesBystdRegNo(aStudentRegNo).Data;


                var aDepartmentId = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .DepartmentId;
                var aDepartmentName = _dbContext.Departments.SingleOrDefault(x => x.Id == aDepartmentId).Name;
                StudentResult aResult = new StudentResult();
                var astudentEmail = _dbContext.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Email;


                serviceresponse.Data = _dbContext.StudentResults.SingleOrDefault(x =>
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

                else if (serviceresponse.Data == null)
                {
                    if (!serviceresponse.Success)
                    {
                        serviceresponse.Message = "Course is already assigne.";
                        serviceresponse.Success = false;
                    }
                    else
                    {
                        aResult.StudentRegNo = studentResult.StudentRegNo;

                        aResult.Name = astudentName;
                        aResult.CourseName = studentResult.CourseName;
                        aResult.Email = astudentEmail;
                        aResult.DepartmentName = aDepartmentName;
                        aResult.GradeLetter = studentResult.GradeLetter;
                        aResult.Result = true;





                        _dbContext.StudentResults.Add(aResult);
                        _dbContext.SaveChanges();
                        serviceresponse.Data = aResult;
                        //------------------------------------------
                        /*
                        serviceresponse.Success = true;*/

                        serviceresponse.Message = $"{astudentName} will start taking {acourseName}";
                    }
                }
                else if (serviceresponse.Data.Result)
                {
                    serviceresponse.Message = "Course is already Enrolled";
                    serviceresponse.Success = false;
                }
                else
                {

                    aResult.StudentRegNo = studentResult.StudentRegNo;

                    aResult.Name = astudentName;
                    aResult.CourseName = studentResult.CourseName;
                    aResult.Email = astudentEmail;
                    aResult.DepartmentName = aDepartmentName;
                    aResult.GradeLetter = studentResult.GradeLetter;
                    aResult.Result = true;


                    _dbContext.StudentResults.Update(aResult);
                    _dbContext.SaveChanges();
                    serviceresponse.Data = aResult;
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


        //GetCourseByStdRegNo:
        public ServiceResponse<IEnumerable<Course>> GetEnrolledCoursesBystdRegNo(string stdRegNo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                List<Course> CourseList = new List<Course>();
                List<Course> CourseListf = new List<Course>();
                Student aStudent;
                aStudent = _dbContext.Students
                  .SingleOrDefault(x => x.RegistrationNumber == stdRegNo);
                CourseList = _dbContext.Courses.Where(x => x.DepartmentId == aStudent.DepartmentId).ToList();
                if (aStudent != null)
                {

                    foreach (var courseEnroll in _dbContext.CourseEnrolls)
                    {
                        if (courseEnroll != null)
                        {
                            foreach (var course in CourseList)
                            {
                                if (course != null)
                                {
                                    if (courseEnroll.EnrolledCourseId == course.Id)
                                    {
                                        CourseListf.Add(courseEnroll.Course);
                                    }
                                }

                            }
                        }
                    }
                    if (CourseListf != null)
                    {
                        serviceResponse.Data = CourseListf;
                        serviceResponse.Message = "Enrolled courses loaded successfully";
                    }
                    else
                    {
                        serviceResponse.Message = "No COursees Enrolled!!!";
                        serviceResponse.Success = false;
                    }
                }
                else
                {
                    serviceResponse.Message = "student with given reg no does not exist";
                    serviceResponse.Success = false;
                }


            }
            catch (Exception ex)
            {
                serviceResponse.Message = "Error occurred while fetching data from DB for\n" + ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }






        //GetStudentResultByStudentRegNo:
        public ServiceResponse<IEnumerable<StudentResult>> GetResultBystdRegNo(string stdRegNo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<StudentResult>>();
            try
            {
                var Results = new List<StudentResult>();
                List<Course> CourseList = new List<Course>();
                List<CourseEnroll> EnrolledCourseList = new List<CourseEnroll>();

                Student aStudent;
                aStudent = _dbContext.Students
                  .SingleOrDefault(x => x.RegistrationNumber == stdRegNo);
                //Taking list to load courselist of given student
                if (aStudent != null)
                {

                    /* foreach (var result in _dbContext.CourseEnrolls)
                     {
                         if (result.EnrolledStudentId == aStudent.Id)
                         {
                             CourseList.Add(result.Course);
                         }
                     }*/
                    /*CourseList = _dbContext.Courses.Where(x => x.DepartmentId == aStudent.DepartmentId).ToList();*/
                    var response = GetEnrolledCoursesBystdRegNo(stdRegNo);
                    CourseList = (List<Course>)GetEnrolledCoursesBystdRegNo(stdRegNo).Data;
                    if (CourseList != null || !response.Success)
                    {

                        foreach (var course in CourseList)
                        {
                            if (course != null)
                            {
                                foreach (var result in _dbContext.StudentResults)
                                {
                                    if (result != null)
                                    {
                                        /*var student = new Student();
                                        student.RegistrationNumber = stdRegNo;*/
                                        if (course.Name == result.CourseName && result.StudentRegNo == stdRegNo)
                                        {
                                            Results.Add(result);
                                        }
                                    }


                                }
                            }

                        }
                        if (Results != null)
                        {
                            serviceResponse.Data = Results;
                            serviceResponse.Message = "Enrolled course's Result fetched successfully";
                        }
                        else
                        {
                            serviceResponse.Message = "Enrolled course's Result dont published yet";
                            serviceResponse.Success = false;
                        }

                    }
                    else
                    {
                        serviceResponse.Message = "this student does not enrolled in any course yet";
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
