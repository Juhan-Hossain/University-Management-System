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
    }
}
