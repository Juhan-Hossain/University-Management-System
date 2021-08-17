﻿using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.DesignationBLL
{
    public class DesignationServiceBLL : Repository<Designation, ApplicationDbContext>,IDesignationServiceBLL
    {
        public DesignationServiceBLL(ApplicationDbContext dbContext):base(dbContext)
        {

        }
    }
}