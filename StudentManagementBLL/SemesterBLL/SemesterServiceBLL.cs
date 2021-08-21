using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.SemesterBLL
{
    public class SemesterServiceBLL : Repository<Semester, ApplicationDbContext>, ISemesterServiceBLL
    {
        

        public SemesterServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
           
        }

        //GETAllSemesterTo view:
       /* public override ServiceResponse<IEnumerable<Semester>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Semester>>();
            try
            {
                serviceResponse.Data = _dbContext.Semesters.ToList();

                serviceResponse.Message = "Semester data & Assigning teacher fetched successfully from the database";
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }*/
    }
}
