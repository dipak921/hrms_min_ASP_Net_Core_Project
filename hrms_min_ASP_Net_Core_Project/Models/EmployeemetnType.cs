using System.ComponentModel.DataAnnotations;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class EmployeemetnType
    {
        [Key]
        public int Id { get; set; }

        public string EmployeementType { get; set; }

        


        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();


    }
}
