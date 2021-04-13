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
            Map(m => m.Style).Name("sku");
            Map(m => m.AvailableLength).Name("length").Optional();
            Map(m => m.AvrageWeight).Name("weight").Optional();
            Map(m => m.Price).Name("price");
        }
    }
}
