using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.DesignationBLL;
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
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationServiceBLL _service;
        public DesignationsController(IDesignationServiceBLL service)
        {
            _service = service;
        }



        [HttpPost]
        public ActionResult<ServiceResponse<Designation>> PostDesignation(Designation designation)
        {
            designation.Id = 0;
            var serviceResponse = _service.Add(designation);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }

    }
}
