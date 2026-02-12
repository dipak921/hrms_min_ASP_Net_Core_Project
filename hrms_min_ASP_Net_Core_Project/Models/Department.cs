using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        
        [Display(Name = "Department Name")]
        public string Name { get; set; }

    }
}
