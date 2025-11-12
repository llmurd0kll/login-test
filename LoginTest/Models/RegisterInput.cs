using System.ComponentModel.DataAnnotations;

namespace LoginTest.Models
    {
    public class RegisterInput
        {
        [Required] public string Email { get; set; } = "";
        [Required] public string Password { get; set; } = "";

        }
    }
