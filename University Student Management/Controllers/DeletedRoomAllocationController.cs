using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.DeletedRoomAllocationBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    public class DeletedRoomAllocationController : BaseApiController
    {
        private readonly IDeletedRoomAllocationBLL _service;
        public DeletedRoomAllocationController(IDeletedRoomAllocationBLL service)
        {
            _service = service;

        }

        [HttpDelete("UnAllocateRooms")]

        public ActionResult<ServiceResponse<DeletedRoomAllocation>> UnAllocateRooms()
        {

            var response = _service.UnallocatingRooms();
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
