using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.RoomBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController:ControllerBase
    {
        private readonly IRoomBLL _service;
        public RoomController(IRoomBLL service)
        {
            _service = service;
        }


        // GET: api/Teachers:All
        [HttpGet("GetRooms")]
        public ActionResult<ServiceResponse<IEnumerable<Room>>> GetRooms()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }
    }
}
