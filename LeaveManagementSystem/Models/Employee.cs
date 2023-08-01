using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public int EmployeeDOB { get; set; }
        public string Email{ get; set; }
        public string password { get; set; }
        public ICollection<Leave> Leaves { get; set; } // Navigation property
    }
}
