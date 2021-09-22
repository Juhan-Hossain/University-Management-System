using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DayBLL
{
    public class DayBLL : Repository<WeekDay, ApplicationDbContext>, IDayBLL
    {
        private readonly ApplicationDbContext Context;

        public DayBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<WeekDay>> DayDDl(string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<WeekDay>>();
            List<WeekDay> ddl = new List<WeekDay>();
            List<WeekDay> fddl = new List<WeekDay>();
            ddl = Context.weekDays.Where(x => x.DayName.Contains(str)).ToList();
            var x = 0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no Room with given name exists!!";
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
