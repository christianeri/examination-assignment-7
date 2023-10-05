using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class ContactRequestEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}
