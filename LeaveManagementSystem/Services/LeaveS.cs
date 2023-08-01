using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public class LeaveS
    {
        private ILeave _Leaves;
        public LeaveS(ILeave leave)
        {
            _Leaves = leave;
            
        }
        public Leave AddLeave(Leave leave)
        {
            return _Leaves.AddLeave(leave);
        }
        public string UpdateLeave(Leave leave)
        {
            return _Leaves.UpdateLeave(leave);
        }
        public string DeleteLeave(int LeaveId)
        {
            return _Leaves.DeleteLeave(LeaveId);
        }

        public List<Leave> GetAllLeaves()
        {
            return _Leaves.GetAllLeaves();
        }
        public List<Leave> GetLeave(int LeaveId)
        {
            return _Leaves.GetLeave(LeaveId);
        }
    }
}
