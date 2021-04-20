using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO.Mapper
{
    public class ExportProductsMapper : ClassMap<AddProductDto>
    {
        public ExportProductsMapper()
        {
            Map(m => m.Style).Name("SKU");
            Map(m => m.AvailableLength).Name("LENGTH");
            Map(m => m.AvrageWeight).Name("WEIGHT");
            Map(m => m.Price).Name("PRICE");
            Map(m => m.ValidationMessage).Name("ERROR MESSAGE");
        }
    }
}
