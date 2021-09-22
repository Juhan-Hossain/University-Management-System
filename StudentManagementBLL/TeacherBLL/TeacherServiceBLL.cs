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
        private readonly ApplicationDbContext Context;

        public TeacherServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }


        //GET:GET teacher by department:
        public ServiceResponse<IEnumerable<Teacher>> GetTeachersByDepartment(int departmentId,string str)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Teacher>>();
            try
            {
                serviceResponse.Data = Context.Teachers.Where(x => x.DepartmentId == departmentId && x.Name.Contains(str)).ToList();

                serviceResponse.Message = "teacher with the given dept.id &  was fetched successfully from the database";
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Some error occurred while fetching teacher by dept.id ";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


    }
}
