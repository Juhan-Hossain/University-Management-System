using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.GradeBLL
{
    public class GradeBLL : Repository<StudentGrade, ApplicationDbContext>, IGradeBLL
    {
        private readonly ApplicationDbContext Context;

        public GradeBLL(ApplicationDbContext dbContext):base(dbContext)
        {
            this.Context = dbContext;
        }

        public ServiceResponse<IEnumerable<StudentGrade>> GradeDDl(string str)
        {
            var DropDownListData = FindDDL(x => x.Grade.Contains(str));
            var service = new ServiceResponse<IEnumerable<StudentGrade>>();
            if (DropDownListData.Success)
            {
                service.Data = DropDownListData.Data.Take(10).OrderBy(x=>x.value).ToList();
                service.Message = DropDownListData.Message;
                service.Success = DropDownListData.Success;
            }
            return service;
        }

    }
}
