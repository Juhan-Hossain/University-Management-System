using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.GradeBLL
{
    public class GradeBLL : Repository<StudentGrade, ApplicationDbContext>, IGradeBLL
    {
        private readonly ApplicationDbContext Context;

        public GradeBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<StudentGrade>> GradeDDl(string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<StudentGrade>>();
            List<StudentGrade> ddl = new List<StudentGrade>();
            List<StudentGrade> fddl = new List<StudentGrade>();
            ddl = Context.StudentGrades.Where(x => x.Grade.Contains(str)).ToList();
            var x = 0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no grade with given name exists!!";
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
                fddl= fddl.OrderBy(o => o.value).ToList();
                serviceResponse.Data = fddl;
                serviceResponse.Message = " ddl load success";
            }
            return serviceResponse;
        }

    }
}
