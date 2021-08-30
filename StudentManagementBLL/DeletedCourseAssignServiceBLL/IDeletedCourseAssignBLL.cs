using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DeletedCourseAssignServiceBLL
{
    public interface IDeletedCourseAssignBLL : IRepository<DeletedCourseAssign>
    {
        public ServiceResponse<DeletedCourseAssign> UnassignTeacher();
    }
}
