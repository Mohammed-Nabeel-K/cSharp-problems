using System.ComponentModel.DataAnnotations;

namespace weekTwoDayFive.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [MinLength(6)]
        public string Usename { get; set; }

        [Required,MinLength(6)]
        
        public string Password { get; set; }
        public string Roles { get; set; }

        

    }

    public class LoginModel
    {
        public string Usename { get; set; }
        public string Password { get; set; }

        
    }
}
