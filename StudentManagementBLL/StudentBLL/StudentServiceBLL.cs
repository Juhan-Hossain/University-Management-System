using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.StudentBLL
{
    public class StudentServiceBLL : Repository<Student,ApplicationDbContext>,IStudentServiceBLL
    {
        public StudentServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        public override ServiceResponse<Student> AddDetails(Student student)
        {
            var serviceResponse = new ServiceResponse<Student>();

            try
            {
                var newid =student.Id ;
                student.Id = 0;

                //finding corresponding department for code
                var adepartment = _dbContext.Departments.Find(student.DepartmentId);
                
                var newstudent = new Student();
                newstudent = student;
                
                //adding registration number for new student
                newstudent.RegistrationNumber = $"{adepartment.Code}-{student.Date.Date.Year}-{newid}";
                serviceResponse.Data = newstudent;
                _dbContext.Students.Add(newstudent);
                _dbContext.SaveChanges();
                
                serviceResponse.Message = "Student created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Storing action failed in the database for given student\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


    }
}
