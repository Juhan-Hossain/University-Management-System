using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.ClassScheduleBLL
{
    public interface IClassScheduleBLL : IRepository<ClassSchedule>
    {
        public ServiceResponse<IEnumerable<ClassSchedule>> GetScheduleByDept(int deptId);
    }
}
