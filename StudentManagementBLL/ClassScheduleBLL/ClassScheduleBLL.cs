using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace StudentManagementBLL.ClassScheduleBLL
{
    public class ClassScheduleBLL : Repository<ClassSchedule, ApplicationDbContext>, IClassScheduleBLL
    {
        private readonly ApplicationDbContext Context;
        public ClassScheduleBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<ClassSchedule>> GetScheduleByDept(int deptId)
        {
            var service = new ServiceResponse<IEnumerable<ClassSchedule>>();
            _dbContext.Database.ExecuteSqlRaw("EXEC SpViewRoomAllocation");
            var schedulestart = Context.ClassSchedules.ToList();
            var courses = Context.Courses.Where(x=>x.DepartmentId==deptId).ToList();
            List<ClassSchedule> finalSchedule= new List<ClassSchedule>();
            foreach (var item in schedulestart)
            {
                if (courses.Any(x => x.Code == item.Course))
                {
                    finalSchedule.Add(item);
                }
            }
            if(finalSchedule.Count<=0)
            {
                service.Message = "no schedule has found";
               /* service.Success = false;*/
            }
            else
            {
                service.Data = finalSchedule;
                service.Message = "schedule loaded successfully";
            }
            return service;
        }
    }
}
