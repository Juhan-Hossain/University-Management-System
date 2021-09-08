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
    public class StudentResultController : BaseApiController
    {
        private readonly IStudentResultBLL _service;
        public StudentResultController(IStudentResultBLL service)
        {
            _service = service;
        }


        // POST: api/StudentResult/CreateStudentResult
        [HttpPost("CreateStudentResult")]
        public ActionResult<ServiceResponse<StudentResult>> CreateStudentResult(StudentResult studentResult)
        {

            var serviceResponse = _service.Add(studentResult);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        //Get: api/StudentResult
        [HttpGet("GetStudentResult")]
        public ActionResult<ServiceResponse<StudentResult>> GetStudentResult(string StudentRegNo)
        {
            var serviceResponse = _service.GetResultBystdRegNo(StudentRegNo);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
    }
}
