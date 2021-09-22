using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.GradeBLL;
using StudentManagementEntity;

namespace University_Student_Management.Controllers
{
    public class GradesController : BaseApiController
    {
        private readonly IGradeBLL _service;
        public GradesController(IGradeBLL service)
        {
            _service = service;
        }

        // GET: api/Grades:All
        [HttpGet("GetGrades")]
        public ActionResult<ServiceResponse<IEnumerable<StudentGrade>>> GetGrades()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }
        [HttpGet("LoadGradeDDL")]
        public ActionResult<ServiceResponse<IEnumerable<StudentGrade>>> LoadGradeDDL(string str)
        {
            var serviceResponse = _service.GradeDDl(str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
    }
}
