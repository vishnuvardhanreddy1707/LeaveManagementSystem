using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LeaveManagementSystem.DATA
{
    public class LeaveDBContext: DbContext
    
    {
        public LeaveDBContext(DbContextOptions<LeaveDBContext> options) : base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }

    }
}
