using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseBLL
{
    public class CourseServiceBLL : Repository<Course, ApplicationDbContext>, ICourseServiceBLL
    {
        public CourseServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {


        }


        //GET:All:COurse
      /*  public override ServiceResponse<IEnumerable<Course>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                serviceResponse.Data = _dbContext.Courses.Include(x => x.).ToList();

                serviceResponse.Message = "Course data & Assigning teacher fetched successfully from the database";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }*/

        //POST:Course
        public override ServiceResponse<Course> Add(Course course)
        {
            var serviceResponse = new ServiceResponse<Course>();

            try
            {
                serviceResponse.Data = course;
                _dbContext.Courses.Add(serviceResponse.Data);
                _dbContext.SaveChanges();
                serviceResponse.Message = "Designation created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Storing action failed in the database for given designation\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        


        //GetCoursesByDept:
        public ServiceResponse<IEnumerable<Course>> GetCourseByDepartment(int departmentId,string courseCode)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                serviceResponse.Data = _dbContext.Courses
                    .Include(x => x.Department)
                    .Where(x => x.DepartmentId == departmentId).ToList();

                serviceResponse.Message = "Data  with the given id was fetched successfully from the database";
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        //ViewCourseByDept:
        public ServiceResponse<IEnumerable<Course>> AssignedCoursesByDepartment(int departmentId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                var data = new List<Course>();
                var courses = _dbContext.Courses;
                foreach (Course course in courses)
                {
                    if (course.DepartmentId == departmentId)
                    {
                        if (course.AssignTo != null)
                        {
                            data.Add(course);
                        }
                        else
                        {
                            course.AssignTo = "Not Assigned Yet!";
                            data.Add(course);
                        }
                    }
                    

                }
                serviceResponse.Data = data;

                
                if (data.Count()>0)
                {
                    serviceResponse.Message = "Data  with the given id was fetched successfully from the database";
                }
                else
                {
                    serviceResponse.Message = "This dept does not have any data!";
                    serviceResponse.Success = false;
                }

                
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //GetCourseByStdRegNo
        public ServiceResponse<IEnumerable<Course>> ViewCourseBystdRegNo(string stdRegNo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                Student aStudent;
                 aStudent = _dbContext.Students
                   .SingleOrDefault(x => x.RegistrationNumber == stdRegNo);
                if(aStudent != null)
                {
                    var tempcourses = _dbContext.Courses
                        .Include(x => x.Department)
                    .Where(x => x.DepartmentId == aStudent.DepartmentId).ToList(); ;

                    /*foreach (Course course in tempcourses)
                    {
                        if ()
                    }*/
                    if (tempcourses is null)
                    {
                        serviceResponse.Message = "student do not exist";
                        serviceResponse.Success = false;
                    }

                    serviceResponse.Message = "Data  with the given id was fetched successfully from the database";
                }
                else
                {
                    serviceResponse.Message = "Student does not exist";
                    serviceResponse.Success = false;
                }

                
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

/*        //Get Enrolled Courses By StdReg No:

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
                *//*  CourseList = (List<Course>)ViewCourseBystdRegNo(stdRegNo).Data;*/
                /*CourseList = _dbContext.Courses
                        .Include(x => x.CourseEnrolls).ThenInclude(x => x.IsEnrolled)
                        
                        .ToList();*//*
                if (aStudent != null)
                {

                    foreach (var courseEnroll in _dbContext.CourseEnrolls)
                    {
                        if (courseEnroll != null && courseEnroll.IsEnrolled)
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
        }*/



    }
}
