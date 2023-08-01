using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Interfaces
{
    public interface IEmployee
    {
        public Employee AddEmployee(Employee employee);
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(int EmployeeID);
        public List<Employee> GetAllEmployees();
        public List<Employee> SearchEmplyee(int EmployeeID);

    }
}
