using System.ComponentModel.DataAnnotations;

namespace Revision_of_CRUDE.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public int StudetnId { get; set; }

        [Required,Display(Name ="Student Name")]
        public string StudetnName { get; set; }

        [Required, Display(Name = "Student Email")]
        public string StudetnEmail { get; set; }

        [Required, Display(Name = "Student Course")]
        public string StudetnCourse { get; set; }

        [Required, Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
    }
}
