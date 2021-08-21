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
        public override ServiceResponse<IEnumerable<Course>> GetDetailsAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                serviceResponse.Data = _dbContext.Courses.Include(x => x.Teacher).ToList();

                serviceResponse.Message = "Course data & Assigning teacher fetched successfully from the database";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //POST:Course
        public override ServiceResponse<Course> AddDetails(Course course)
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


        //validates the fact of course assignment
        public virtual ServiceResponse<Course> GetByCompositeKey(int departmentId, string Code,int teacherId)
        {
            var serviceResponse = new ServiceResponse<Course>();
            try
            {
                serviceResponse.Data =  _dbContext.Courses.Include(x => x.Teacher)
                    .SingleOrDefault(x => (x.DepartmentId == departmentId
                                            && x.Code == Code) && x.TeacherId!=teacherId);
                /* if(serviceResponse.Data.Credit>serviceResponse.Data.TeacherId.)*/

                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = "Data not found with the given constrain.";
                    serviceResponse.Success = false;
                }
                else
                {
                    //Checking remaining credit
                    Teacher aTeacher = _dbContext.Teachers.FirstOrDefault(t=> t.Id==teacherId);
                    Course aCourse = _dbContext.Courses.FirstOrDefault(c => c.Code == Code);
                    if(aTeacher.RemainingCredit>=aCourse.Credit)
                    {
                        aTeacher.RemainingCredit -= aCourse.Credit;
                        aTeacher.CreditTaken += aCourse.Credit;
                        serviceResponse.Message = $"{aTeacher.Name} will start taking {aCourse.Code}: {aCourse.Name}";
                    }
                    else
                    {
                        serviceResponse.Message = $"{aTeacher.Name} does not have time to take {aCourse.Code}: {aCourse.Name}";
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



        public ServiceResponse<IEnumerable<Course>> GetCourseDetailsByDepartment(int departmentId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                serviceResponse.Data = _dbContext.Courses
                    .Include(x => x.Teacher)
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
