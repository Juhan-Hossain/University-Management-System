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
    public class TeachersController : BaseApiController
    {
        private readonly ITeacherServiceBLL _service;
        public TeachersController(ITeacherServiceBLL service)
        {
            _service = service;
        }

        // GET: api/Teachers:All
        [HttpGet("GetTeachers")]
        public ActionResult<ServiceResponse<IEnumerable<Teacher>>> GetTeachers()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }

        [HttpGet("TeacherDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Teacher>>> GetTeachersByIdAndStr(int departmentId, string str)
        {
            var serviceResponse = _service.GetTeachersByDepartment(departmentId, str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


        // POST: api/CreateTeacher
        [HttpPost("CreateTeacher")]
        public ActionResult<ServiceResponse<Teacher>> CreateTeacher(Teacher teacher)
        {
            teacher.RemainingCredit = teacher.CreditToBeTaken;
            var serviceResponse = _service.Add(teacher);
            if (serviceResponse.Success == false)
            {
                serviceResponse.Message = "Create unique name & email for teacher";
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }


    }
}
