using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DayBLL
{
    public interface IDayBLL : IRepository<WeekDay>
    {
        public ServiceResponse<IEnumerable<WeekDay>> DayDDl(string str);
    }
}
