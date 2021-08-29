using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.StudentResultBLL
{
    public interface IStudentResultBLL : IRepository<StudentResult>
    {
        public ServiceResponse<IEnumerable<StudentResult>> GetResultBystdRegNo(string StudentRegNo);
    }
}
