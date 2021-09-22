using RepositoryLayer;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.RoomBLL
{
    public interface IRoomBLL : IRepository<Room>
    {
        public ServiceResponse<IEnumerable<Room>> RoomDDl(string str);
    }
}
