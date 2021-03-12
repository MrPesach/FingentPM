using System;
using System.ComponentModel.DataAnnotations;

namespace RCG.Domain.Entities
{
    public class DomainObject
    {
        [Key]
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
