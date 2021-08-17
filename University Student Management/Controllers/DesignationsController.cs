using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.DesignationBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationServiceBLL _service;
        public DesignationsController(IDesignationServiceBLL service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<ServiceResponse<Designation>> PostDepartment(Designation designation)
        {
            designation.Id = 0;
            var serviceResponse = _service.AddDetails(designation);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Designation>>> GetDepartments()
        {
            var serviceResponse = _service.GetDetailsAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }
    }
}
