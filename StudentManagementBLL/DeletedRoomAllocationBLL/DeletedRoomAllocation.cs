using RepositoryLayer;
using StudentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DeletedRoomAllocationBLL
{
    public class DeletedRoomAllocation : Repository<DeletedRoomAllocation, ApplicationDbContext>, IDeletedRoomAllocation
    {
        public DeletedRoomAllocation(ApplicationDbContext dbContext):base(dbContext)
        {

        }
    }
}
