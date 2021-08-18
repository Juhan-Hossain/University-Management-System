using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseBLL
{
   public interface ICourseServiceBLL : IRepository<Course>
   {
        public ServiceResponse<Course> GetByCompositeKey(int departmentId, string courseCode,int teacherId);
        public ServiceResponse<IEnumerable<Course>> GetCourseDetailsByDepartment(int departmentId);
    }
}
