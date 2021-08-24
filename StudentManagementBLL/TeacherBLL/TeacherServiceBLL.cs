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


        //GET:GET teacher by department:
        public ServiceResponse<IEnumerable<Teacher>> GetTeacherByDepartment(int departmentId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Teacher>>();
            try
            {
                serviceResponse.Data = _dbContext.Teachers.Where(x => x.DepartmentId == departmentId).ToList();

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
