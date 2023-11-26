using Employee_Application.Models;
using Employee_Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmloyees()
        {
            var result = await _employeeService.GetEmployee();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
              var result = await _employeeService.GetEmpByID(id);
              if (result == null)
              {
                  return NotFound("Employee does not exists");
              }
              return Ok(result);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employees employee)
        {
            var result = await _employeeService.CreateEmployee(employee);
            return StatusCode(201, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeByID(int id, [FromQuery] Employees employee)
        {
            var result = await _employeeService.UpdateEmp(id, employee);
            if (result == null)
            {
                return BadRequest("Inavlaid Id");
            }
            return Ok(result);

        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartOfEmployee(int id, [FromQuery] Employees employee)
        {
            var result = await _employeeService.UpdatePartOfEmp(id, employee);
            if (result == null)
            {
                return BadRequest("Inavlaid Details");
            }
            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmp(id);
            if (result == null)
            {
                return BadRequest("Employee does not exists");
            }
            return Ok(result);
        }
    }
}
