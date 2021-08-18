using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using StudentManagementBLL.DepartmentBLL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace University_Student_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentServiceBLL _service;
        public DepartmentsController(IDepartmentServiceBLL service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<ServiceResponse<Department>> PostDepartment([FromBody] Department department)
        {
            /*department.Id = 0;*/
            var serviceResponse = _service.AddDetails(department);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse.Data);
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Department>>> GetDepartments()
        {
            var serviceResponse =  _service.GetDetailsAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse.Message);
            return Ok(serviceResponse);
        }
    }

    

}
