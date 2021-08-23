using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.TeacherBLL
{
    public class TeacherServiceBLL: Repository<Teacher, ApplicationDbContext>, ITeacherServiceBLL
    {
        public TeacherServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }


    }
}
