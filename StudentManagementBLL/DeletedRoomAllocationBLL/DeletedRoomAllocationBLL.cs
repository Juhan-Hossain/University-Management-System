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
            _dbContext.Database.ExecuteSqlRaw("execute SpGetDeletedRoomAllocationTable01");
            serviceResponse.Message = "Unallocated All Rooms";
            serviceResponse.Success = true;
            Context.SaveChanges();
            return serviceResponse;
        }
    }
}
