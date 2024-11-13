using System.ComponentModel.DataAnnotations;

namespace WeekFourDaySix.Models
{

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Teacher { get; set; }
    }

}
