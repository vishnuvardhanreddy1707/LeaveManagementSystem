using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeS _employeeS;
        public EmployeeController(EmployeeS employeeS)
        {
            _employeeS = employeeS;     
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            return Ok(_employeeS.AddEmployee(employee));
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            return Ok(_employeeS.DeleteEmployee(EmployeeId));
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            return Ok(_employeeS.UpdateEmployee(employee));
        }
        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            return _employeeS.GetAllEmployees();
        }
        [HttpGet("GetEmployee")]
        public List<Employee> GetEmployee(int EmployeeId)
        {
            return _employeeS.SearchEmplyee(EmployeeId);
        }

    }
}
