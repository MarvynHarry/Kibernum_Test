using System.ComponentModel.DataAnnotations;

namespace Kibernum_Back.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
