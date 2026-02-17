using System.ComponentModel.DataAnnotations;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
