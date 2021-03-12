using System.ComponentModel.DataAnnotations;

namespace RCG.Domain.Entities
{
    public class ProductMain : DomainObject
    {
        [Required]
        public string FileActualname { get; set; }

        [Required]
        public string FileTempname { get; set; }

    }
}
