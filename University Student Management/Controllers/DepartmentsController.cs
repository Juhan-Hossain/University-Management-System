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
    public class DepartmentsController : BaseApiController
    {
        private readonly IDepartmentServiceBLL _service;
        public DepartmentsController(IDepartmentServiceBLL service)
        {
            _service = service;
        }


        [HttpPost("CreateDepartment")]
        public ActionResult<ServiceResponse<Department>> CreateDepartment([FromBody] Department department)
        {
            /*department.Id = 0;*/
            var serviceResponse = _service.Add(department);
            if (serviceResponse.Success == false)
            {
                serviceResponse.Message = "Department already exist in DB!";
                return BadRequest(serviceResponse);
            }
            serviceResponse.Message = "Department added successfully";
            return Ok(serviceResponse);
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Department>>> GetDepartments()
        {
            var serviceResponse =  _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }


        [HttpGet("LoadDeptDDL")]
        public ActionResult<ServiceResponse<IEnumerable<Department>>> LoadDepartment(string str)
        {
         
            var service = _service.DepartmentDDl(str);
            if (service.Success == true)
            {
                return Ok(service);
            }
            return BadRequest(service);
        }
    }

    

}
