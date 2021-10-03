using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DayBLL
{
    public class DayBLL : Repository<WeekDay, ApplicationDbContext>, IDayBLL
    {
        private readonly ApplicationDbContext Context;

        public DayBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<WeekDay>> DayDDl(string str)
        {
            var DropDownListData = FindDDL(x => x.DayName.Contains(str));
            var service = new ServiceResponse<IEnumerable<WeekDay>>();
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
