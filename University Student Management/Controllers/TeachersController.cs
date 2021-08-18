using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.TeacherBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController:ControllerBase
    {
        private readonly ITeacherServiceBLL _service;
        public TeachersController(ITeacherServiceBLL service)
        {
            _service = service;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Teacher>>> GetDepartments()
        {
            var serviceResponse = _service.GetDetailsAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }


        // POST: api/Departments
        [HttpPost]
        public ActionResult<ServiceResponse<Teacher>> PostDepartment( Teacher teacher)
        {
            teacher.Id = 0;
            var serviceResponse = _service.AddDetails(teacher);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse.Data);
        }
    }
}
