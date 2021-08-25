using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DepartmentBLL
{
    public class DepartmentServiceBLL:Repository<Department,ApplicationDbContext>,IDepartmentServiceBLL
    {
        public DepartmentServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

       /* public override ServiceResponse<Department> Add(Department department)
        {
            var serviceResponse = new ServiceResponse<Department>();

            try
            {
                var newId = department.Id;
                serviceResponse.Data = department;
                _dbContext.Departments.Add(serviceResponse.Data);
                _dbContext.SaveChanges();
                serviceResponse.Message = "Department created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"please enter valid department code beetween 2-7 char & new name\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }*/
    }
}
