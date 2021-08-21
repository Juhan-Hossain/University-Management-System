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
    [ApiController]
    [Route("api/[controller]")]
    public class SemestersController:ControllerBase
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

        
    }


}
