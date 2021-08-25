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
        [HttpGet("CoursesByDepartment&Code")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCoursesByDepartment(int departmentId,string courseCode)
        {
            var serviceResponse = _service.GetCourseByDepartment(departmentId,courseCode);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        // GET: Courses
        [HttpGet("ViewCoursesByDepartment")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> ViewCoursesByDept(int departmentId)
        {
            var serviceResponse = _service.AssignedCoursesByDepartment(departmentId);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        //POST:Course
        [HttpPost("CreateCourse")]
        
        public ActionResult<ServiceResponse<Course>> CreateCourse(Course course)
        {
           
            var serviceResponse = _service.Add(course);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpGet("CoursesByStudentRegNo")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCoursesByStudentRegNo(string stdRegNo)
        {
            var serviceResponse = _service.ViewCourseBystdRegNo(stdRegNo);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


     /*   [HttpGet("EnrolledCoursesByStudentRegNo")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> EnrolledCoursesByStudentRegNo(string stdRegNo)
        {
            var serviceResponse = _service.GetEnrolledCoursesBystdRegNo(stdRegNo);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }*/





    }
}
