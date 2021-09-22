using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.SemesterBLL
{
    public interface ISemesterServiceBLL : IRepository<Semester>
    {
        public ServiceResponse<IEnumerable<Semester>> SemesterDDl(string str);
    }
}
