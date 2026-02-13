using System.ComponentModel.DataAnnotations;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name ="City Name")]
        public string CityName { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();



    }
}
