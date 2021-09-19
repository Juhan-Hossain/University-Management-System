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
    
    public class CourseEnrollController : BaseApiController
    {
        private readonly ICourseEnrollBLL _service;
        public CourseEnrollController(ICourseEnrollBLL service)
        {
            _service = service;

        }

        [HttpPost("CreateCourseEnroll")]

        public ActionResult<ServiceResponse<CourseEnroll>> CourseEnrollment([FromBody] CourseEnroll courseEnroll)
        {

            var response = _service.EnrollCourseToStudent(courseEnroll.StudentRegNo, courseEnroll.CourseCode);
            if (!response.Success) return BadRequest(response);

           /* response.Message = $" {courseEnroll.StudentRegNo} Successfully enrolled by student {courseEnroll.CourseCode}";*/
            return Ok(response);

        }


    }
}
