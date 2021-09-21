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
        public ServiceResponse<IEnumerable< Department>> DepartmentDDl(string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Department>>();
            List<Department> ddl = new List<Department>();
            List<Department> fddl = new List<Department>();
            ddl = Context.Departments.Where(x => x.Name.Contains(str)).ToList();
            var x=0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no dept with given name exists!!";
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
            for(int i=0;i<x;i++)
            {
                fddl.Add(ddl[i]);
            }
            if(serviceResponse.Success)
            {
                serviceResponse.Data = fddl;
                serviceResponse.Message = " ddl load success";
            }
            return serviceResponse;
        }

    }
}
