using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using StudentManagementBLL.StudentBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    public class StudentsController : BaseApiController
    {
        private readonly IStudentServiceBLL _service;
      
        public StudentsController(IStudentServiceBLL service)
        {
            _service = service;

        }

        //Post:CreateStudent
        [HttpPost("CreateStudent")]

        public ActionResult<ServiceResponse<Student>> CreateStudent(Student student)
        {
            

            var serviceResponse = _service.Add(student);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


        [HttpGet("GetStudents")]
        public ActionResult<ServiceResponse<IEnumerable<Student>>> GetStudents()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpGet("LoadStdDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Department>>> LoadStudent(string str)
        {
            var serviceResponse = _service.StudentDDl(str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


    }
}
