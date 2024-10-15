using Microsoft.AspNetCore.Mvc;
using weekTwoDayOne.EmployeeList;
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
            var employeelist = EmployeeList.EmployeeList.employees.Select(n => n);
            return employeelist;
        }

        public EmployeeModel getEmployee(int id)
        {
            var employee = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeId == id ).FirstOrDefault();
            return employee;
        }

        public EmployeeModel createEmployee([FromBody] EmployeeModel employee)
        {
            EmployeeList.EmployeeList.employees.Add(employee);
            return employee;
        }
        public EmployeeModel updateEmployee([FromBody] EmployeeModel employee)
        {
            var employeeold = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeId == employee.EmployeeId).FirstOrDefault();
            employeeold.EmployeeId = employee.EmployeeId;
            employeeold.EmployeeName = employee.EmployeeName;
            employeeold.EmployeePosition = employee.EmployeePosition;
            return employee;
        }
        public bool deleteEmplyee(int id)
        {
            var employee = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeId == id).FirstOrDefault();
            EmployeeList.EmployeeList.employees.Remove(employee);
            return (true);
            
        }


    }
}
