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
            Room aRoom = Context.Rooms.SingleOrDefault(x => x.Id == body.RoomId);

            var start = body.StartTime;
            var end = body.EndTime;

            if (start == end || start > end)
            {
                serviceresponse.Message = "please enter a valid start & end time";
                serviceresponse.Success = false;
                return serviceresponse;
            }
            RoomAllocationList SelectedRoom = Context.RoomAllocationLists.SingleOrDefault(x => x.DayId == body.DayId && x.RoomId == body.RoomId
                && (x.StartTime < end && x.EndTime > start)
            );
            serviceresponse.Data = SelectedRoom;
            if(SelectedRoom!=null)
            {
                serviceresponse.Message = $"Room {aRoom.Name} is busy right now";
                serviceresponse.Success = false;
                return serviceresponse;
            }
            if(SelectedRoom==null)
            {
                try
                {
                    body.CourseId = aCourse.Id;
                    Context.RoomAllocationLists.Add(body);
                    Context.SaveChanges();
                    serviceresponse.Message = $"{aCourse.Name} is Successfully allocated to {aRoom.Name}";
                }
                catch (Exception ex)
                {
                    serviceresponse.Message = "error occured while allocating room";
                    serviceresponse.Success = false;
                }
            }
            return serviceresponse;
        }

        public ServiceResponse<IEnumerable<RoomAllocationList>> GetByCourseCode(string code)
        {
            var serviceresponse = new ServiceResponse<IEnumerable<RoomAllocationList>>();


            List<RoomAllocationList> ByDept = Context.RoomAllocationLists.Where(x => x.CourseCode == code).ToList();

            if (ByDept.Count == 0)
            {
                serviceresponse.Message = "please add room allocation for this dept.";
                serviceresponse.Success = false;
                return serviceresponse;
            }

            serviceresponse.Data = ByDept;

            serviceresponse.Message = "Added dept based room allocation list";


            return serviceresponse;
        }

        public ServiceResponse<IEnumerable<RoomAllocationList>> GetByDeptId(int id)
        {
            var serviceresponse = new ServiceResponse<IEnumerable<RoomAllocationList>>();


            List<RoomAllocationList> ByDept = Context.RoomAllocationLists.Where(x => x.DepartmentId==id).ToList();

            if(ByDept.Count==0)
            {
                serviceresponse.Message = "please enter dept. ID";
                serviceresponse.Success = false;
                return serviceresponse;
            }

            serviceresponse.Data = ByDept;

            serviceresponse.Message = "Added dept based room allocation list";


            return serviceresponse;
        }
       /* public ServiceResponse<IEnumerable<RoomAllocationList>> GetRoomAllocationList(int deptId)
        {
            var p = Context.DeletedRoomAllocations.fromSqlRaw("EXEC SpViewRoomAllocation");
        }
*/
    }
}
