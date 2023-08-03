using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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


        #region LoginModel

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _employeeS.GetEmployeebyEmail(model.Email);
            if (user != null && model.password == user.password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       new Claim("EmployeeId", user.EmployeeId.ToString()),
                       new Claim("Email", user.Email.ToString()),
                       new Claim("EmployeeName",user.EmployeeName.ToString())

                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("55f6UmNJfrbdi8It")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Email or Password is incorrect." });
            }
        }
        #endregion

    }
}
