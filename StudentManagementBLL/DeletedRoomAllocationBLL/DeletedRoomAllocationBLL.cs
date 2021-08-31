using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DeletedRoomAllocationBLL
{
    public class DeletedRoomAllocationBLL : Repository<DeletedRoomAllocation, ApplicationDbContext>, IDeletedRoomAllocationBLL
    {
        private readonly ApplicationDbContext Context;

        public DeletedRoomAllocationBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<DeletedRoomAllocation> UnallocatingRooms()
        {
            var serviceResponse = new ServiceResponse<DeletedRoomAllocation>();

            var allocationLists = Context.RoomAllocationLists;


            DeletedRoomAllocation deletedRoomAllocation = new DeletedRoomAllocation();

            Context.DeletedRoomAllocations.FromSqlRaw<DeletedRoomAllocation>("SpGetDeletedRoomAllocationTable01");

            foreach (RoomAllocationList allocation in allocationLists)
            {
                /*Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Code == assign.Code);
                Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == assign.TeacherId);
                Department fetchingDepartment = Context.Departments.SingleOrDefault(x => x.Id == assign.DepartmentId);*/

                deletedRoomAllocation.CourseCode = allocation.CourseCode;
                deletedRoomAllocation.DayId = allocation.DayId;
                deletedRoomAllocation.DepartmentId = allocation.DepartmentId;
                deletedRoomAllocation.EndTime = allocation.EndTime;
                deletedRoomAllocation.StartTime = allocation.StartTime;
                deletedRoomAllocation.RoomId = allocation.RoomId;
                deletedRoomAllocation.FromMeridiem = allocation.FromMeridiem;
                deletedRoomAllocation.ToMeridiem = allocation.ToMeridiem;






                Context.RoomAllocationLists.Remove(allocation);
                Context.DeletedRoomAllocations.Add(deletedRoomAllocation);

            }
            serviceResponse.Message = "Unallocated All Rooms";
            serviceResponse.Success = true;
            Context.SaveChanges();



            return serviceResponse;
        }

       
    }
}
