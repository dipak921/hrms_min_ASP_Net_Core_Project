using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(50)]
        public string Desigantion { get; set; }

       
        [Required(ErrorMessage = "Joining Date is required")]
        [Column("Date of Joining", TypeName = "varchar(50)")]
        public DateTime JoingDate  { get; set; }

        [Required]
        [Range(1000, 10000000, ErrorMessage = "Salary must be between 1000 and 1000000")]
        [Precision(18,2)]
        public decimal Salary { get; set; }

        [Display(Name = "Profile Image Path")]
        public string? ProfileImage {get; set; }
}
}
