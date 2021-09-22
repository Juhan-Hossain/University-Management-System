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
        public ServiceResponse<IEnumerable<Course>> GetCourseByDepartmentAndStr(int departmentId, string str);
        public ServiceResponse<IEnumerable<Course>> AssignedCoursesByDepartment(int departmentId);
        public ServiceResponse<IEnumerable<Course>> ViewCourseBystdRegNo(string stdRegNo, string str);
        public ServiceResponse<IEnumerable<Course>> GetEnrolledCoursesBystdRegNo(string stdRegNo, string str);
        public ServiceResponse<IEnumerable<Course>> ViewCoursesByDept(int departmentId);
        public ServiceResponse<IEnumerable<Course>> EnrolledCoursesBystdRegNoDDL(string stdRegNo);



    }
}
