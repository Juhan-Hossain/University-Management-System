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
    public class RoomAllocationController : BaseApiController
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
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
           
        }
        [HttpGet("AllocatedRooms")]
        public ActionResult<ServiceResponse<IEnumerable<RoomAllocationList>>> GetAllocatedRooms()
        {
            var serviceResponse = _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
        [HttpGet("CourseCode")]
        public ActionResult<ServiceResponse<IEnumerable<RoomAllocationList>>> GetRoomsByCourseCode(string code)
        {
            var serviceResponse = _service.GetByCourseCode(code);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
        [HttpGet("DepartmentId")]
        public ActionResult<ServiceResponse<IEnumerable<RoomAllocationList>>> GetRoomsByDeptId(int id)
        {
            var serviceResponse = _service.GetByDeptId(id);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }

    }
}
