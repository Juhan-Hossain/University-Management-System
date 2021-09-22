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
    
    public class CoursesController : BaseApiController
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
        [HttpGet("CoursesByDepartmentAndStrDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCoursesByDepartment(int departmentId,string str)
        {
            var serviceResponse = _service.GetCourseByDepartmentAndStr(departmentId,str);
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

        //https://localhost:44322/api/Courses/GetCoursesByDepartment
        [HttpGet("GetCoursesByDepartment")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCoursesByDept(int departmentId)
        {
            var serviceResponse = _service.ViewCoursesByDept(departmentId);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        //POST:Course
        [HttpPost("CreateCourse")]
        
        public ActionResult<ServiceResponse<Course>> CreateCourse(Course course)
        {
           
            var serviceResponse = _service.Add(course);
            if (serviceResponse.Success == false)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("CoursesByStudentRegNoDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCoursesByStudentRegNo(string stdRegNo,string str)
        {
            var serviceResponse = _service.ViewCourseBystdRegNo(stdRegNo,str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


        [HttpGet("EnrolledCoursesByStudentRegNoDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> EnrolledCoursesByStudentRegNo(string stdRegNo,string str)
        {
            var serviceResponse = _service.GetEnrolledCoursesBystdRegNo(stdRegNo,str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpGet("EnrolledCoursesByStdRegDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> EnrolledCoursesByStdRegNo(string stdRegNo)
        {
            var serviceResponse = _service.EnrolledCoursesBystdRegNoDDL(stdRegNo);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }



    }
}
