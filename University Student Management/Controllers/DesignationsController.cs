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
    public class DesignationsController : BaseApiController
    {
        private readonly IDesignationServiceBLL _service;
        public DesignationsController(IDesignationServiceBLL service)
        {
            _service = service;
        }



     

        // GET: api/Teachers:All
        [HttpGet("GetDesignations")]
        public ActionResult<ServiceResponse<IEnumerable<Designation>>> GetDesignations()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }
        [HttpPost]
        public ActionResult<ServiceResponse<Designation>> PostDesignation(Designation designation)
        {
            designation.Id = 0;
            var serviceResponse = _service.Add(designation);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }

        [HttpGet("LoadDesignationDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Designation>>> LoadDesignation(string str)
        {
            var serviceResponse = _service.DesignationDDl(str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

    }
}
