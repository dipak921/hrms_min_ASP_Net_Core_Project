using System.ComponentModel.DataAnnotations;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public Employee? Employee { get; set; }

    }
}
