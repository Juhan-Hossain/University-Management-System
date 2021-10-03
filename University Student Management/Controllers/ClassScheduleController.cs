using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.ClassScheduleBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    public class ClassScheduleController : BaseApiController
    {
        private readonly IClassScheduleBLL _service;
        public ClassScheduleController(IClassScheduleBLL service)
        {
            _service = service;
        }
        [HttpGet("GetScheduleByDepartment")]
        public ActionResult<ServiceResponse<IEnumerable<ClassSchedule>>> getScheduleListByDept(int departmentId)
        {
            var serviceResponse = _service.GetScheduleByDept(departmentId);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
    }
}
