using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO
{
    public class PriceListDto
    {
        public int ProductId { get; set; }
        public string Style { get; set; }
        public string AvailableLength { get; set; }
        public string AvrageWeight { get; set; }
        public string Price { get; set; }
    }
}
