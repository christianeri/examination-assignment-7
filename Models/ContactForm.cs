using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class ContactForm
    {
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Name { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(450, MinimumLength = 2)]
        public string Message { get; set; } = null!;
        
        [Required]
        public string RedirectURL { get; set; } = "/contacts";
    }
}
