using Microsoft.EntityFrameworkCore;
using hrms_min_ASP_Net_Core_Project.Models;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EmployeemetnType> EmployeemetnTypes { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
