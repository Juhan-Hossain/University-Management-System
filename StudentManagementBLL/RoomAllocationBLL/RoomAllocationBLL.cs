using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.RoomAllocationBLL
{
    public class RoomAllocationBLL : Repository<RoomAllocationList, ApplicationDbContext>, IRoomAllocationBLL
    {
        private readonly ApplicationDbContext Context;

        public RoomAllocationBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<RoomAllocationList> CreateRoomAllocation(RoomAllocationList body)
        {
            var serviceresponse = new ServiceResponse<RoomAllocationList>();
            Course aCourse = Context.Courses.SingleOrDefault(x => x.Code == body.CourseCode);
            Department aDepartment = Context.Departments.SingleOrDefault(x => x.Id == body.DepartmentId);
            Room aRoom = Context.Rooms.SingleOrDefault(x => x.Id == body.RoomId);
            WeekDay aDay = Context.weekDays.SingleOrDefault(x => x.Id == body.DayId);
            RoomAllocationList SelectedRoom = Context.RoomAllocationLists.Find();




            return serviceresponse;
        }









    }
}
