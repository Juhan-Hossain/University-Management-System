using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.CourseEnrollBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseEnrollController : ControllerBase
    {
        private readonly ICourseEnrollBLL _service;
        public CourseEnrollController(ICourseEnrollBLL service)
        {
            _service = service;

        }

        
    }
}
