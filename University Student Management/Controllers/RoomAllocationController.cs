using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.RoomAllocationBLL;
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
    public class RoomAllocationController : ControllerBase
    {
        private readonly IRoomAllocationBLL _service;
        public RoomAllocationController(IRoomAllocationBLL service)
        {
            _service = service;

        }

        [HttpPost("AllocateRooms")]

        public ActionResult<ServiceResponse<RoomAllocationList>> AllocateRoom([FromBody] RoomAllocationList body)
        {
            var response = _service.CreateRoomAllocation(body);


            if (response.Success)
            {
                response.Message = $" {body.CourseCode} Successfully assign to RoomId no: {body.RoomId}";
                return Ok(response);
            }
            else
            {
                response.Message = "error occured while allocating rooms";
                return BadRequest(response);
            }
           
        }

    }
}
