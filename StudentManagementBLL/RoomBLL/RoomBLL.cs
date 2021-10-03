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
        private readonly ApplicationDbContext Context;

        public RoomBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<Room>> RoomDDl(string str)
        {
            var DropDownListData = FindDDL(x => x.Name.Contains(str));
            var service = new ServiceResponse<IEnumerable<Room>>();
            if (DropDownListData.Success)
            {
                service.Data = DropDownListData.Data.Take(10).ToList();
                service.Message = DropDownListData.Message;
                service.Success = DropDownListData.Success;
            }
            return service;
        }
    }
}
