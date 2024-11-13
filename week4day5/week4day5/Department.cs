public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    // Navigation property for employees
    public virtual ICollection<Employee> Employees { get; set; }
}