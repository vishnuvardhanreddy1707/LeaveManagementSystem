using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Interfaces
{
    public interface ILeave
    {
        public Leave AddLeave(Leave leave);
        public string UpdateLeave(Leave leave);
        public string DeleteLeave(int LeaveId);
        public List<Leave> GetAllLeaves();
        public List<Leave> GetLeave(int LeaveId);
    }
}
