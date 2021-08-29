using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.RoomAllocationBLL
{
    public interface IRoomAllocationBLL : IRepository<RoomAllocationList>
    {
        public ServiceResponse<RoomAllocationList> CreateRoomAllocation(RoomAllocationList body);
    }
}
