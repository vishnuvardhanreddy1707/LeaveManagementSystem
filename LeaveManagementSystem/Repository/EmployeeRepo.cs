using LeaveManagementSystem.DATA;
using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private LeaveDBContext _dbContext;
        public EmployeeRepo(LeaveDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public string DeleteEmployee(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Employee> SearchEmplyee(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public string UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
