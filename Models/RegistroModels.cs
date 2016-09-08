using System.ComponentModel.DataAnnotations;

namespace WebGomeet.Models
{
    public class RegistroModels
    {
        [StringLength(60,MinimumLength = 3)]       
        public string Nombre { get; set; }

        [StringLength(100,MinimumLength = 3)]
        public string Email { get; set; }

        [StringLength(100,MinimumLength = 5)]
        public string Clave { get; set; }
        
    }
}