using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeekFourDayFive.Models;

namespace WeekFourDayFive.DB
{
    public class YourDatabaseContext : DbContext
    {
        public YourDatabaseContext(DbContextOptions<YourDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
