using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.SemesterBLL
{
    public class SemesterServiceBLL : Repository<Semester, ApplicationDbContext>, ISemesterServiceBLL
    {
        private readonly ApplicationDbContext Context;

        public SemesterServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }
        public ServiceResponse<IEnumerable<Semester>> SemesterDDl(string str)
        {
            var DropDownListData = FindDDL(x => x.Name.Contains(str));
            var service = new ServiceResponse<IEnumerable<Semester>>();
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
