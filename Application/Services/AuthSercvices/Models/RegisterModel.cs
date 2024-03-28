using System.ComponentModel.DataAnnotations;

namespace Application.Services.AuthSercvices.Models
{
    public class RegisterModel
    { 
        [Required, StringLength(50),EmailAddress]
        public string Username { get; set; } = null!;

        [Required, StringLength(128)]
        public string Email { get; set; } = null!;

        [Required, StringLength(256)]
        public string Password { get; set; } = null!;
    }
}
