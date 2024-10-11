using Microsoft.AspNetCore.Mvc;
using weekTwoDayOne.Models;
using weekTwoDayOne.EmployeeList;

namespace weekTwoDayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<EmployeeModel> GetEmployeeData()
        {
            return EmployeeList.EmployeeList.employees;
        }

        [HttpGet ("{id}")]
        public EmployeeModel GetEmployeeDataById(int id)
        {
            var employee = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeId == id).FirstOrDefault() ;
            return employee;
        }

        [HttpDelete]
        public bool DeleteEmployeeDataById(int id)
        {
            var employee = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeId == id).FirstOrDefault();
            EmployeeList.EmployeeList.employees.Remove(employee);
            return true;
        }

        [HttpPut]
        public bool UpdateEmployeeDataById(int id, string name, string position)
        {
            var employee = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeId == id).FirstOrDefault();
            employee.EmployeeName = name;
            employee.EmployeePosition = position;
            return true;
        }
        [HttpGet("{name:alpha}", Name ="getemployeeByName")]
        public EmployeeModel GetEmployeeDataByName(string name)
        {
            var employee = EmployeeList.EmployeeList.employees.Where(n => n.EmployeeName == name).FirstOrDefault();
            return employee;
        }


    }
}
