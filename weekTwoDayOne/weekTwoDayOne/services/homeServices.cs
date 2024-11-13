using Microsoft.AspNetCore.Mvc;
using weekTwoDayOne.EmployeeLis;
using weekTwoDayOne.Models;

namespace weekTwoDayOne.services
{
    public interface IhomeServices
    {
        public IEnumerable<EmployeeModel> getData();
        public EmployeeModel getEmployee(int id);
        public EmployeeModel createEmployee([FromBody] EmployeeModel employee);
        public EmployeeModel updateEmployee([FromBody] EmployeeModel employee);
        public bool deleteEmplyee(int id);
    }
    public class homeServices : IhomeServices
    {
        public IEnumerable<EmployeeModel> getData() {
            var employeelist = EmployeeLis.EmployeeList.employees.Select(n => n);
            return employeelist;
        }

        public EmployeeModel getEmployee(int id)
        {
            var employee = EmployeeLis.EmployeeList.employees.Where(n => n.EmployeeId == id ).FirstOrDefault();
            return employee;
        }

        public EmployeeModel createEmployee([FromBody] EmployeeModel employee)
        {
            EmployeeLis.EmployeeList.employees.Add(employee);
            return employee;
        }
        public EmployeeModel updateEmployee([FromBody] EmployeeModel employee)
        {
            var employeeold = EmployeeLis.EmployeeList.employees.Where(n => n.EmployeeId == employee.EmployeeId).FirstOrDefault();
            employeeold.EmployeeId = employee.EmployeeId;
            employeeold.EmployeeName = employee.EmployeeName;
            employeeold.EmployeePosition = employee.EmployeePosition;
            return employee;
        }
        public bool deleteEmplyee(int id)
        {
            var employee = EmployeeLis.EmployeeList.employees.Where(n => n.EmployeeId == id).FirstOrDefault();
            EmployeeLis.EmployeeList.employees.Remove(employee);
            return (true);
            
        }


    }
}
