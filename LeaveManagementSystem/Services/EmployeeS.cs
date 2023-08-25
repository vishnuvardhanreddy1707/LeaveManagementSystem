using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public class EmployeeS
    {
        private IEmployee _employee;
        public EmployeeS(IEmployee employee)
        {
            _employee = employee;
                
        }
        public Employee AddEmployee(Employee employee)
        {
            return _employee.AddEmployee(employee);
        }
        public string UpdateEmployee(Employee employee)
        {
            return _employee.UpdateEmployee(employee);
        }
        public string DeleteEmployee(int EmployeeId)
        {
            return _employee.DeleteEmployee(EmployeeId);
        }
        public List<Employee> GetAllEmployees()
        {
            return _employee.GetAllEmployees();
        }
        public Employee GetEmployee(int EmployeeID)
        {
            return _employee.GetEmployee(EmployeeID);
        }

        public Employee GetEmployeebyEmail(string Email)
        {
            return _employee.GetEmployeebyEmail(Email);
        }
    }
}
