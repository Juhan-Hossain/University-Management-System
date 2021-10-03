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
        private readonly ApplicationDbContext Context;

        public DesignationServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public override ServiceResponse<Designation> Add(Designation designation)
        {
            var serviceResponse = new ServiceResponse<Designation>();

            try
            {
                designation.Id = 0;
                serviceResponse.Data = designation;
                Context.Designations.Add(serviceResponse.Data);
                Context.SaveChanges();
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

        public ServiceResponse<IEnumerable<Designation>> DesignationDDl(string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Designation>>();
            List<Designation> DropDownListData = new List<Designation>();
            List<Designation> fddl = new List<Designation>();
            DropDownListData = Context.Designations.Where(x => x.Name.Contains(str)).Take(10).ToList();
            if (DropDownListData.Count <= 0)
            {
                serviceResponse.Message = "no Designation with given name exists!!";
                serviceResponse.Success = false;
            }
            if (serviceResponse.Success)
            {
                serviceResponse.Data = DropDownListData;
                serviceResponse.Message = " ddl load success";
            }
            return serviceResponse;
        }
    }
}
