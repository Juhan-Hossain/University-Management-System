using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DesignationBLL
{
    public class DesignationServiceBLL : Repository<Designation, ApplicationDbContext>,IDesignationServiceBLL
    {
        public DesignationServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        public override ServiceResponse<Designation> Add(Designation designation)
        {
            var serviceResponse = new ServiceResponse<Designation>();

            try
            {
                designation.Id = 0;
                serviceResponse.Data = designation;
                _dbContext.Designations.Add(serviceResponse.Data);
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
