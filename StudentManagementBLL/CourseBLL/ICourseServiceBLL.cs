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
        public ServiceResponse<IEnumerable<Course>> GetCourseByDepartment(int departmentId, string courseCode);
        public ServiceResponse<IEnumerable<Course>> AssignedCoursesByDepartment(int departmentId);
        public ServiceResponse<IEnumerable<Course>> ViewCourseBystdRegNo(string stdRegNo);



    }
}
