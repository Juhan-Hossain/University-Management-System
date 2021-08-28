using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.DayBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayController :ControllerBase
    {
        private readonly IDayBLL _service;
        public DayController(IDayBLL service)
        {
            _service = service;
        }

        // GET: api/Teachers:All
        [HttpGet("GetDays")]
        public ActionResult<ServiceResponse<IEnumerable<WeekDay>>> GetDays()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }


    }
}
