using System.ComponentModel.DataAnnotations;

namespace Application.Services.AuthSercvices.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
