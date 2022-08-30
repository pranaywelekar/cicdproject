using JWTHandsOn.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTHandsOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Roles ="Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository repo;
        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> employees = repo.GetEmployees();
            return employees;

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            Employee emp = repo.GetEmployee(id);
            if (emp == null)
                return NotFound($"Employee with id : {id} not found");
            return Ok(emp);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Employee emp)
        {
            if (emp.Id <= 0)
                return BadRequest("Invalid employee id");

            Employee employee = repo.UpdateEmployee(emp);
            if (employee == null)
                return BadRequest("Invalid employee id");
            return Ok(employee);


        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            List<Employee> employees = repo.CreateEmployee(emp);
            return Ok(employees);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleteEmployee = repo.DeleteEmployee(id);
            if (!deleteEmployee)
                return BadRequest("Delete failed");
            return Ok($"Deleted the employee with id: {id}");
        }
    }
}
