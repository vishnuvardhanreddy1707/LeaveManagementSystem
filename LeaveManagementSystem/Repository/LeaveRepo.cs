using LeaveManagementSystem.DATA;
using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repository
{
    public class LeaveRepo : ILeave

    {
        private LeaveDBContext _dbContext;
        public LeaveRepo(LeaveDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Leave AddLeave(Leave leave)
        {
            try
            {

                _dbContext.Leaves.Add(leave);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }

            return leave;
        }

        public string DeleteLeave(int LeaveId)
        {
            string Result = string.Empty;
            Leave delete;

            try
            {
                delete = _dbContext.Leaves.Find(LeaveId);

                if (delete != null)
                {
                    _dbContext.Leaves.Remove(delete);

                    _dbContext.SaveChanges();
                    Result = "200";
                }
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            finally
            {
                delete = null;
            }
            return Result;
        }

        public List<Leave> GetAllLeaves()
        {
            List<Leave> leaves = null;
            try
            {
                leaves = _dbContext.Leaves.ToList();
            }
            catch (Exception ex)
            {

            }
            return leaves;
        }

        public List<Leave> GetLeave(int LeaveId)
        {
            List<Leave> leaves = null;
            var getleave = _dbContext.Leaves.Where(v => v.LeaveId == LeaveId);
            try
            {
                if (getleave != null)
                {

                    leaves = getleave.ToList();
                    return leaves;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return leaves;
        }

        public string UpdateLeave(Leave leave)
        {
            string stCode = string.Empty;

            try
            {

                _dbContext.Entry(leave).State = EntityState.Modified;
                _dbContext.SaveChanges();
                //stCode = "200";

            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }
    }
}
