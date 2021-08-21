using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.TeacherBLL
{
    public class TeacherServiceBLL: Repository<Teacher, ApplicationDbContext>, ITeacherServiceBLL
    {
        public TeacherServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        //POST:Teacher
        public override ServiceResponse<Teacher> Add(Teacher teacher)
        {
            var serviceResponse = new ServiceResponse<Teacher>();

            try
            {
                teacher.RemainingCredit = teacher.CreditToBeTaken;
                serviceResponse.Data = teacher;
                _dbContext.Teachers.Add(serviceResponse.Data);
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
    }
}
