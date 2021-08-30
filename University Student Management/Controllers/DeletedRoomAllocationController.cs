using Microsoft.AspNetCore.Mvc;
using StudentManagementBLL.DeletedRoomAllocationBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeletedRoomAllocationController:ControllerBase
    {
        private readonly IDeletedRoomAllocation _service;
        public DeletedRoomAllocationController(IDeletedRoomAllocation service)
        {
            _service = service;

        }
    }
}
