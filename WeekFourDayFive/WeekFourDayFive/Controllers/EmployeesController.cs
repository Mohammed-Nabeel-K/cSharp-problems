using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeekFourDayFive.DB;
using WeekFourDayFive.DTOs;
using WeekFourDayFive.Models;

namespace WeekFourDayFive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly YourDatabaseContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(YourDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var createdEmployeeDto = _mapper.Map<EmployeeDTO>(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployeeDto.EmployeeId }, createdEmployeeDto);
        }
    }

}
