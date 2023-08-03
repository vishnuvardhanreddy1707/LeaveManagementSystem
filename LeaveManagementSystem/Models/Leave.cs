using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class Leave
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int LeaveId { get; set; }
       // [ForeignKey("Employee")]
        //Required(ErrorMessage = "Employee Id is required")]
        public int EmployeeId { get; set; }
       // public Employee Employee { get; set; }
        public string EmployeeName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LeaveName { get; set; }
        public string LeaveDescription { get; set;}
        public string status { get; set; } = "submitted";
        public string StatusDescription { get; set; }





    }
}
