using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.CourseAssignBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseAssignmentController:ControllerBase
    {
        private readonly ICourseAssignServiceBLL _service;
        public CourseAssignmentController(ICourseAssignServiceBLL service)
        {
            _service = service;

        }

        [HttpGet("CourseAssignment")]
        public ActionResult<ServiceResponse<IEnumerable<CourseAssignment>>> GetCourseAssignments()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }


        [HttpPost("CreateCourseAssignment")]

        public ActionResult<ServiceResponse<CourseAssignment>> CourseAssignment([FromBody] CourseAssignment body)
        {

            var coursekeyresponse = _service.AssignCourseToTeacher(body.DepartmentId, body.Code, body.TeacherId);

            //checking if a teacher can be assigned to a course
           /* if (!coursekeyresponse.Success || coursekeyresponse.Data == null )
            {
                coursekeyresponse.Success = false;
                coursekeyresponse.Message = $"Can not Assign {body.Code} to TeacherId no: {body.TeacherId}";
                return BadRequest(coursekeyresponse);
            }*/

            /*coursekeyresponse.Data.TeacherId = body.TeacherId;*/
           /* var updateresponse = _service.Add(coursekeyresponse.Data);*/
            if (!coursekeyresponse.Success) return BadRequest(coursekeyresponse);

            coursekeyresponse.Message = $" {body.Code} Successfully assign to TeacherId no: {body.TeacherId}";
            return Ok();

        }


    }
}
