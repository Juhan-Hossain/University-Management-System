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
        private readonly ApplicationDbContext Context;

        public DepartmentServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }

        public override ServiceResponse<Department> Add(Department department)
        {
            var serviceResponse = new ServiceResponse<Department>();

            try
            {
                var newId = department.Id;
              /*  department.Id = 0;*/
                serviceResponse.Data = department;
                Context.Departments.Add(serviceResponse.Data);
                Context.SaveChanges();
                serviceResponse.Message = "Department created successfully in DB";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"this department already exist\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
