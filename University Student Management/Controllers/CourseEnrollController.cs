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

        [HttpPost("CreateCourseEnroll")]

        public ActionResult<ServiceResponse<CourseEnroll>> CourseEnrollment(string stdregno,string coursename)
        {

            var response = _service.EnrollCourseToStudent(stdregno,coursename);
            if (!response.Success) return BadRequest(response);

            response.Message = $" {coursename} Successfully enrolled by student {stdregno}";
            return Ok(response);

        }


    }
}
