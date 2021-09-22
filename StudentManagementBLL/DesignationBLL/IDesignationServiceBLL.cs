using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DesignationBLL
{
    public interface IDesignationServiceBLL :IRepository<Designation>
    {
        public ServiceResponse<IEnumerable<Designation>> DesignationDDl(string str);
    }
}
