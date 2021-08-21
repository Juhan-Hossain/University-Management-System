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


        



        public ServiceResponse<IEnumerable<Course>> GetCourseByDepartment(int departmentId)
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



    }
}
