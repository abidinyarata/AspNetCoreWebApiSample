using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AuthModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
