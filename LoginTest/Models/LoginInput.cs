using System.ComponentModel.DataAnnotations;

namespace LoginTest.Models
    {
    public class LoginInput
        {
        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; } = "";

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; } = "";
        }
    }
