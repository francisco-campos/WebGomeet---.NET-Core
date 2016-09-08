using System.ComponentModel.DataAnnotations;

namespace WebGomeet.Models
{
    public class LoginModels
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 5)]
        public string Clave { get; set; }
        
    }
}