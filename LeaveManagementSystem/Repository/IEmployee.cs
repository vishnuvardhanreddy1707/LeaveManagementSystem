using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Interfaces
{
    public interface IEmployee
    {
        public Employee AddEmployee(Employee employee);
        public Employee GetEmployeebyEmail(string Email);
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(int EmployeeId);
        public List<Employee> GetAllEmployees();
        public Employee GetEmployee(int EmployeeId);

    }
}
