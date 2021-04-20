using System.ComponentModel.DataAnnotations;

namespace RCG.Domain.Entities
{
    public class Users : DomainObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
