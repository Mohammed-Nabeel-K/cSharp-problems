using Microsoft.AspNetCore.Mvc;
using weekTwoDayOne.Models;
using weekTwoDayOne.EmployeeList;
using weekTwoDayOne.services;

namespace weekTwoDayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IhomeServices _ihomeservices;

        public HomeController(IhomeServices homeservices){
            _ihomeservices = homeservices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> GetEmployeeData()
        {

            return Ok(_ihomeservices.getData());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeModel> GetEmployeeDataById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _ihomeservices.getEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> DeleteEmployeeDataById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _ihomeservices.deleteEmplyee(id);
            if (employee == null)
                return NotFound();

            return Ok(true);
        }


        
        [HttpPost("create")]
        public ActionResult AddEmployee([FromBody] EmployeeModel employee)
        {
            var res = _ihomeservices.createEmployee(employee);
            
            return Ok(res);
        }

        [HttpPut]
        [Route("update")]

        public ActionResult<EmployeeModel> UpdateEmployee([FromBody] EmployeeModel employee) 
        {
            if (employee == null || employee.EmployeeId <= 0)
                return BadRequest();

            var res  = (_ihomeservices.updateEmployee(employee));

            return Ok(res);
        }


    }
}
