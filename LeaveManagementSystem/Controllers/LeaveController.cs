using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private LeaveS _leaveS;
        public LeaveController(LeaveS leaveS)
        {
            _leaveS = leaveS;
        }
        [HttpPost("AddLeave")]
        public IActionResult AddLeave(Leave leave)
        {
            return Ok(_leaveS.AddLeave(leave));
        }
        [HttpDelete("DeleteLeave")]
        public IActionResult DeleteLeave(int LeaveId)
        {
            return Ok(_leaveS.DeleteLeave(LeaveId));
        }
        [HttpPut("UpdateLeave")]
        public IActionResult UpdateLeave(Leave leave)
        {
            return Ok(_leaveS.UpdateLeave(leave));
        }


        [HttpGet("GetAllLeaves")]
        public List<Leave> GetAllLeavess()
        {
            return _leaveS.GetAllLeaves();
        }

        [HttpGet("GetLeave")]
        public List<Leave> GetLeave(int  LeaveId)
        {
            return _leaveS.GetLeave(LeaveId);
        }
    }
}
