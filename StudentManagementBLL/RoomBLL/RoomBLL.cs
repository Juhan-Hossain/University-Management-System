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
            var serviceResponse = new ServiceResponse<IEnumerable<Room>>();
            List<Room> ddl = new List<Room>();
            List<Room> fddl = new List<Room>();
            ddl = Context.Rooms.Where(x => x.Name.Contains(str)).ToList();
            var x = 0;
            if (ddl.Count <= 0)
            {
                serviceResponse.Message = "no Room with given name exists!!";
                serviceResponse.Success = false;
            }
            if (ddl.Count >= 10)
            {
                x = 10;
            }
            else
            {
                x = ddl.Count;
            }
            for (int i = 0; i < x; i++)
            {
                fddl.Add(ddl[i]);
            }
            if (serviceResponse.Success)
            {
                serviceResponse.Data = fddl;
                serviceResponse.Message = " ddl load success";
            }
            return serviceResponse;
        }
    }
}
