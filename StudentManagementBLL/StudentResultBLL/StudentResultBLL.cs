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
                string aStudentRegNo = Context.Students.SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo).ToString();
                //fetching course with id
                int aCourseId = Context.Courses.SingleOrDefault(x => x.Name == studentResult.CourseName).Id;
                //fetching student name with reg no
                string astudentName = Context.Students
                        .SingleOrDefault(x => x.RegistrationNumber == studentResult.StudentRegNo)
                        .Name;
                //fetching coursename 
                string acourseName = Context.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName)
                    .Name;
                //------------------------------------------------------------------

                string acourseCode = Context.Courses
                    .SingleOrDefault(x => x.Name == studentResult.CourseName).Code;
                List<Course> courseList = new List<Course>();
                //get enrolled course list from GetEnrolledCoursesBystdRegNo()
                courseList = (List<Course>)GetEnrolledCoursesBystdRegNo(aStudentRegNo).Data;

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

                            serviceresponse.Message = $"{astudentName} will start taking {acourseName}";
                        }
                        catch (Exception ex)
                        {
                            serviceresponse.Message = "Error occured while adding student result\n" +
                                ex.Message;
                            serviceresponse.Success = false;
                        }


                    }
                }
                //already exist result for this syudent with this course
                else if (serviceresponse.Data.Result)
                {
                    serviceresponse.Message = "already exist result for this syudent with this course";
                    serviceresponse.Success = false;
                }
                else
                {
                    try
                    {
                        //this block updating already existing student result
                        aResult.StudentRegNo = studentResult.StudentRegNo;

                        aResult.Name = astudentName;
                        aResult.CourseName = studentResult.CourseName;
                        aResult.Email = astudentEmail;
                        aResult.DepartmentName = aDepartmentName;
                        aResult.GradeLetter = studentResult.GradeLetter;
                        aResult.Result = true;


                        Context.StudentResults.Update(aResult);
                        Context.SaveChanges();
                        serviceresponse.Data = aResult;
                        serviceresponse.Message = "student result Updated";
                    }
                    catch (Exception ex)
                    {
                        serviceresponse.Message = "This error occured while updating student result\n" +
                            ex.Message;
                        serviceresponse.Success = false;
                    }


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
                aStudent = Context.Students
                  .SingleOrDefault(x => x.RegistrationNumber == stdRegNo);
                CourseList = Context.Courses.Where(x => x.DepartmentId == aStudent.DepartmentId).ToList();
                if (aStudent != null)
                {
                    try
                    {
                        foreach (var courseEnroll in Context.CourseEnrolls)
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
                    }
                    catch (Exception ex)
                    {
                        serviceResponse.Message = "Error occured while fetching enrolled course with loop\n" +
                            ex.Message;
                        serviceResponse.Success = false;
                    }

                    //succeded in fetching course
                    if (CourseListf != null)
                    {
                        serviceResponse.Data = CourseListf;
                        serviceResponse.Message = "Enrolled courses loaded successfully";
                    }
                    else
                    {
                        serviceResponse.Message = "No Courses Enrolled found!!!";
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
                aStudent = Context.Students
                  .SingleOrDefault(x => x.RegistrationNumber == stdRegNo);
                //Taking list to load courselist of given student
                if (aStudent != null)
                {
                    var response = GetEnrolledCoursesBystdRegNo(stdRegNo);
                    CourseList = (List<Course>)GetEnrolledCoursesBystdRegNo(stdRegNo).Data;



                    if (CourseList != null || !response.Success)
                    {
                        try
                        {
                            foreach (var course in CourseList)
                            {
                                if (course != null)
                                {
                                    foreach (var result in Context.StudentResults)
                                    {
                                        if (result != null)
                                        {
                                            
                                            if (course.Name == result.CourseName && result.StudentRegNo == stdRegNo)
                                            {
                                                Results.Add(result);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            serviceResponse.Message = "error occured while adding result in container with loop \n" +
                                ex.Message;
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

                serviceResponse.Message = "Some error occurred while fetching result.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
