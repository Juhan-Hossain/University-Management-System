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


        private readonly ApplicationDbContext _dbContext;
        public CoursesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //getting all course
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Course>>> GetCourses()
        {
            var serviceResponse = _service.GetDetailsAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }

        //getting department list
        [HttpGet]
        public IEnumerable<Department> GetDepartment()
        {
            var listOfDepartments = _dbContext.Departments.ToList();
            return listOfDepartments;
        }

        public IEnumerable<Semester> GetSemester()
        {
            var listOfSemesters = _dbContext.Semesters.ToList();
            return listOfSemesters;
        }



        [HttpPost]
        
        public ActionResult<ServiceResponse<Course>> PostCourse([FromBody] Course course)
        {
            /*course.Id = 0;*/
            var serviceResponse = _service.AddDetails(course);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse.Data);
        }






    }
}
