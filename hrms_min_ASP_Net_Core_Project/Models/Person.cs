using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms_min_ASP_Net_Core_Project.Models
{
    public class Person
    {
        // INT
        [Key]
        public int Id { get; set; }

        // STRING
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        // BYTE
        [Range(1, 120)]
        public byte Age { get; set; }

        // LONG
        [Phone]
        public long PhoneNumber { get; set; }

        // DECIMAL
        [Range(0, 1000000)]
        public decimal Salary { get; set; }

        // FLOAT
        [Range(1.0, 8.0)]
        public float Height { get; set; }

        // DOUBLE
        public double Weight { get; set; }

        // BOOL
        public bool IsMarried { get; set; }

        // CHAR
        public char GenderInitial { get; set; }

        // DATETIME
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        // TIMESPAN
        public TimeSpan WorkingHours { get; set; }

        // NULLABLE TYPE
        public int? OptionalScore { get; set; }

        // EMAIL
        [EmailAddress]
        public string Email { get; set; }

        // URL
        [Url]
        public string Website { get; set; }

        // PASSWORD
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        // OBJECT
        //public object ExtraData { get; set; }


        
            // ENUM
        public Gender PersonGender { get; set; }

        // ARRAY
        public string[] Skills { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

