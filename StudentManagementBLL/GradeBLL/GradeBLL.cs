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
    }
}
