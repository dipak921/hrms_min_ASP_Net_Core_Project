using System.ComponentModel.DataAnnotations;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }


        [Required, Display(Name = "Leave Type")]
        public LeaveType LeaveType { get; set; }

        [Required,DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Required, DataType(DataType.Date)]

        public DateTime ToDate { get; set; }

        public string Status { get; set; } = "Pending";

        public string? Remarks { get; set; } 

        public Employee? Employee { get; set; } 



    }
}
