using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.TeacherBLL
{
    public interface ITeacherServiceBLL: IRepository<Teacher>
    {
        public ServiceResponse<IEnumerable<Teacher>> GetTeachersByDepartment(int departmentId, string str);
    }
}
