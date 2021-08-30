using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.RoomBLL
{
    public class RoomBLL : Repository<Room, ApplicationDbContext>, IRoomBLL
    {
        public RoomBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }
    }
}
