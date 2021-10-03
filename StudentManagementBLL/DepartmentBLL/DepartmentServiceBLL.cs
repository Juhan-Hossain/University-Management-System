using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DepartmentBLL
{
    public class DepartmentServiceBLL:Repository<Department,ApplicationDbContext>,IDepartmentServiceBLL
    {
        private readonly ApplicationDbContext Context;

        public DepartmentServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }
        public ServiceResponse<IEnumerable< Department>> DepartmentDDl(string str)
        {
            var DropDownListData = FindDDL(x => x.Name.Contains(str));
            var service = new ServiceResponse<IEnumerable<Department>>();
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
