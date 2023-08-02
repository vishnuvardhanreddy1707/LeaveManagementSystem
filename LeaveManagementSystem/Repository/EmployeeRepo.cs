using LeaveManagementSystem.DATA;
using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

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
            try
            {

                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }

            return employee;
        }

        public string DeleteEmployee(int EmployeeId)
        {
            string Result = string.Empty;
            Employee delete;

            try
            {
                delete = _dbContext.Employees.Find(EmployeeId);

                if (delete != null)
                {
                    _dbContext.Employees.Remove(delete);

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

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employee = null;
            try
            {
                employee = _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {

            }
            return employee;
        }

        public List<Employee> SearchEmplyee(int EmployeeID)
        {
            List<Employee> employee = null;
            var getemployee = _dbContext.Employees.Where(v => v.EmployeeId == EmployeeID);
            try
            {
                if (getemployee != null)
                {

                    employee = getemployee.ToList();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return employee;
        }

        public string UpdateEmployee(Employee employee)
        {
            string stCode = string.Empty;

            try
            {

                _dbContext.Entry(employee).State = EntityState.Modified;
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
