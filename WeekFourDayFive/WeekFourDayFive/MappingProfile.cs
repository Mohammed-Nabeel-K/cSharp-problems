using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WeekFourDayFive.DTOs;
using WeekFourDayFive.Models;


namespace WeekFourDayFive
{
   

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Department, DepartmentDTO>();
        }
    }

}
