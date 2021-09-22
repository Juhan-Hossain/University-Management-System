using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.GradeBLL
{
    public interface IGradeBLL :IRepository<StudentGrade>
    {
        public ServiceResponse<IEnumerable<StudentGrade>> GradeDDl(string str);
    }
}
