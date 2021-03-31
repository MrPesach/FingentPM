using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO.Mapper
{
    public class PriceListMapper : ClassMap<AddProductDto>
    {
        public PriceListMapper()
        {
            Map(m => m.Style).Name("SKU");
            Map(m => m.AvailableLength).Name("LENGTH").Optional();
            Map(m => m.AvrageWeight).Name("WEIGHT").Optional();
            Map(m => m.Price).Name("PRICE");
        }
    }
}
