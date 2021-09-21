using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DepartmentBLL
{
    public interface IDepartmentServiceBLL : IRepository<Department>
    {
        public ServiceResponse<IEnumerable<Department>> DepartmentDDl(string str);
    }
}
