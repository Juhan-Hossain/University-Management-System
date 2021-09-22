using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.SemesterBLL
{
    public class SemesterServiceBLL : Repository<Semester, ApplicationDbContext>, ISemesterServiceBLL
    {
        private readonly ApplicationDbContext Context;

        public SemesterServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<Semester>> SemesterDDl(string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Semester>>();
            List<Semester> ddl = new List<Semester>();
            List<Semester> fddl = new List<Semester>();
            ddl = Context.Semesters.Where(x => x.Name.Contains(str)).ToList();
            var x = 0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no semester with given name exists!!";
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
