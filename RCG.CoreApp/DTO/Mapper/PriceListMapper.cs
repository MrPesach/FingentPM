using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO.Mapper
{
    public class PriceListMapper : ClassMap<PriceListDto>
    {
        public PriceListMapper()
        {
            Map(m => m.Style).Name("STYLE#");
            Map(m => m.AvailableLength).Name("AVAILABLE  LENGTH");
            Map(m => m.AvrageWeight).Name("AVG.WT.");
            Map(m => m.Price).Name("TRIPLE KEY UNIT PRICE IN USD");
        }
    }
}
