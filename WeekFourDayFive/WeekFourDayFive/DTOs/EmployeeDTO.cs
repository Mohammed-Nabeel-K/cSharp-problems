﻿namespace WeekFourDayFive.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartmentDTO Department { get; set; }
    }

}