using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseEnrollBLL
{
    public interface ICourseEnrollBLL : IRepository<CourseEnroll>
    {
        public ServiceResponse<CourseEnroll> EnrollCourseToStudent(string sdtRegNo, string courseName);


    }
}
