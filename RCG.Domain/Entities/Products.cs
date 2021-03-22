using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCG.Domain.Entities
{
    public class Products : DomainObject
    {
        [Required]
        public string Sku { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Length { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ProductMain")]
        public long? ProductMainId { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ProductMain ProductMain { get; set; }
    }
}
