using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.StudentResultBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentResultController : ControllerBase
    {
        private readonly IStudentResultBLL _service;
        public StudentResultController(IStudentResultBLL service)
        {
            _service = service;
        }


        // POST: api/CreateTeacher
        [HttpPost("CreateStudentResult")]
        public ActionResult<ServiceResponse<StudentResult>> CreateTeacher(StudentResult studentResult)
        {

            var serviceResponse = _service.Add(studentResult);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse.Data);
        }
    }
}
