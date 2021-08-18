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
        public DepartmentServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
