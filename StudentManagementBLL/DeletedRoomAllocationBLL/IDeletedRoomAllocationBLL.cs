using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DeletedRoomAllocationBLL
{
    public interface IDeletedRoomAllocationBLL : IRepository<DeletedRoomAllocation>
    {
        public ServiceResponse<DeletedRoomAllocation> UnallocatingRooms();
    }
}
