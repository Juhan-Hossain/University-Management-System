using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DeletedCourseAssignServiceBLL
{
    public class DeletedCourseAssignBLL : Repository<DeletedCourseAssign, ApplicationDbContext>, IDeletedCourseAssignBLL
    {

        public DeletedCourseAssignBLL(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        

        public ServiceResponse<DeletedCourseAssign> UnassignTeacher(bool flag)
        {
            var serviceResponse = new ServiceResponse<DeletedCourseAssign>();

            var assignCourses = _dbContext.CourseAssignments;

            if (flag)
            {
                DeletedCourseAssign deletedCourseAssign = new DeletedCourseAssign();

                _dbContext.CourseAssignments.FromSqlRaw<CourseAssignment>("SpGetDeletedCourseAssignTable01");
                _dbContext.SaveChanges();




               
                    serviceResponse.Message = "Unassigned All Courses";
                    serviceResponse.Success = true;


               
            }
            return serviceResponse;
        }


    }
}