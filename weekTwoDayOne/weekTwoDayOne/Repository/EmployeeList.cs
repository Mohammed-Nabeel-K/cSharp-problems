using weekTwoDayOne.Models;

namespace weekTwoDayOne.EmployeeLis
{
    public static class EmployeeList
    {
        public static List<EmployeeModel> employees { get; set; } = new List<EmployeeModel>()
        {
            new EmployeeModel() { EmployeeId = 201,EmployeeName = "nabeel", EmployeePosition = "manager" },
            new EmployeeModel() { EmployeeId = 202,EmployeeName = "Adarsh", EmployeePosition = "HR" },
            new EmployeeModel() { EmployeeId = 203,EmployeeName = "Ainas", EmployeePosition = "Creater" }
        };

    }
}
