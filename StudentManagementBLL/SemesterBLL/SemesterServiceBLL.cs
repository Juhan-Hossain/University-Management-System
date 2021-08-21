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
        

        public SemesterServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
           
        }
    }
}
