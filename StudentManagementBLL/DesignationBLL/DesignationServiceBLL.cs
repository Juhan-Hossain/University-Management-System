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
            List<Designation> ddl = new List<Designation>();
            List<Designation> fddl = new List<Designation>();
            ddl = Context.Designations.Where(x => x.Name.Contains(str)).ToList();
            var x = 0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no Designation with given name exists!!";
                serviceResponse.Success = false;
            }
            if (ddl.Count >= 10)
            {
                x = 10;
            }
            else
            {
                x = ddl.Count;
            }
            for (int i = 0; i < x; i++)
            {
                fddl.Add(ddl[i]);
            }
            if (serviceResponse.Success)
            {
                serviceResponse.Data = fddl;
                serviceResponse.Message = " ddl load success";
            }
            return serviceResponse;
        }
    }
}
