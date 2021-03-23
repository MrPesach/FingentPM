using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO
{
    public class PriceListDto
    {
        public long ProductId { get; set; }
        public string Style { get; set; }
        public string AvailableLength { get; set; }
        public string AvrageWeight { get; set; }
        public string Price { get; set; }
        public string UpdatedOn { get; set; }
        public string User { get; set; }
        public long? ProductMainId { get; set; }
    }
}
