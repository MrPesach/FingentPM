using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO
{
    public class ProductMainDto
    {
        public long ProductMainId { get; set; }
        public string FileActualname { get; set; }
        public string FileTempname { get; set; }
        public List<PriceListDto> PriceList { get; set; }
        public string Username { get; set; }
    }
}
