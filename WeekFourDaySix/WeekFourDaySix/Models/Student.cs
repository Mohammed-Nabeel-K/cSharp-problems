using System.ComponentModel.DataAnnotations;

namespace WeekFourDaySix.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
