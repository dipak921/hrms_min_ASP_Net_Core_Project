using System.ComponentModel.DataAnnotations;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class EmployeeDepartment
    {
        public int  Id { get; set; }

        [Required,Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }

        [Required, Display(Name = "Departmetn Name")]
        public int DepartmentId { get; set; }

        [Required, Display(Name = "Employmeng Type")]
        public string EmployeemetnTypeId { get; set; }

        [Required, Display(Name = "Branch Name")]
        public string Branch { get; set; }

        // Navigation properties
        public Employee? Employee { get; set; }
        public EmployeemetnType? EmployeemetnType { get; set; }
        public Department? Department { get; set; }


    }
}
