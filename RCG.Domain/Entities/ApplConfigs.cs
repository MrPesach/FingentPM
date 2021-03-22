using System.ComponentModel.DataAnnotations;

namespace RCG.Domain.Entities
{
    public class ApplConfigs : DomainObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public bool ShowtoUser { get; set; }
    }
}
