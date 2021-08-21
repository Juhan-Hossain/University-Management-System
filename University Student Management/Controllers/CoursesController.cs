using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.CourseBLL;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseServiceBLL _service;
        public CoursesController(ICourseServiceBLL service)
        {
            _service = service;

        }

        //getting all course
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCourses()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        // GET: Courses
        [HttpGet("CoursesByDepartment")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCoursesByDepartment(int departmentId)
        {
            var serviceResponse = _service.GetCourseByDepartment(departmentId);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        //POST:Course
        [HttpPost("CreateCourse")]
        
        public ActionResult<ServiceResponse<Course>> CreateCourse(Course course)
        {
           /* course.Id = 0;*/
            var serviceResponse = _service.Add(course);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


        /*[HttpPost("CourseAssignment")]

        public ActionResult<ServiceResponse<Course>> CourseAssignment([FromBody] CourseAssignment body)
        {
            
            var coursekeyresponse = _service.GetByCompositeKey(body.DepartmentId, body.Code, body.TeacherId);
            
            //checking if a teacher can be assigned to a course
            if (!coursekeyresponse.Success || coursekeyresponse.Data == null || (coursekeyresponse.Data.TeacherId != null))
            {
                coursekeyresponse.Success = false;
                coursekeyresponse.Message = $"Can not Assign {body.Code} to TeacherId no: {body.TeacherId}";
                return BadRequest(coursekeyresponse);
            }
               
            coursekeyresponse.Data.TeacherId = body.TeacherId;
            var updateresponse = _service.UpdateDetails(coursekeyresponse.Data);
            if (!updateresponse.Success) return BadRequest(updateresponse);
                
            coursekeyresponse.Message = $" {body.Code} Successfully assign to TeacherId no: {body.TeacherId}";
            return Ok();
           
        }*/


       /* [HttpPost("CourseEnrollment")]

        public ActionResult<ServiceResponse<Course>> CourseEnrollment([FromBody] CourseAssignment body)
        {

            var coursekeyresponse = _service.GetByCompositeKey(body.DepartmentId, body.Code, body.TeacherId);

            //checking if a teacher can be assigned to a course
            if (!coursekeyresponse.Success || coursekeyresponse.Data == null || (coursekeyresponse.Data.TeacherId != null))
            {
                coursekeyresponse.Success = false;
                coursekeyresponse.Message = $"Can not Assign {body.Code} to TeacherId no: {body.TeacherId}";
                return BadRequest(coursekeyresponse);
            }

            coursekeyresponse.Data.TeacherId = body.TeacherId;
            var updateresponse = _service.UpdateDetails(coursekeyresponse.Data);
            if (!updateresponse.Success) return BadRequest(updateresponse);

            coursekeyresponse.Message = $" {body.Code} Successfully assign to TeacherId no: {body.TeacherId}";
            return Ok();

        }*/

    }
}
