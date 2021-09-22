using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.SemesterBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    public class SemestersController : BaseApiController
    {
        private readonly ISemesterServiceBLL _service;
        public SemestersController(ISemesterServiceBLL service)
        {
            _service = service;
        }

        // GET: api/Semesters:All
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Semester>>> GetAllSemesters()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpGet("LoadSemesterDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Semester>>> LoadSemester(string str)
        {
            var serviceResponse = _service.SemesterDDl(str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


    }


}
