using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseEnrollBLL
{
    public class CourseEnrollBLL : Repository<CourseEnroll, ApplicationDbContext>, ICourseEnrollBLL
    {
        public CourseEnrollBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        
    }
}
