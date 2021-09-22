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
    public class RoomController : BaseApiController
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
        [HttpGet("LoadRoomDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Room>>> LoadRoom(string str)
        {
            var serviceResponse = _service.RoomDDl(str);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
    }
}
