using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCG.Domain.Entities
{
    public class Products : DomainObject
    {
        [Required]
        public string Sku { get; set; }

        public string Length { get; set; }

        public string Weight { get; set; }

        public string Price { get; set; }

        [ForeignKey("ProductMain")]
        public long? ProductMainId { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ProductMain ProductMain { get; set; }
    }
}
