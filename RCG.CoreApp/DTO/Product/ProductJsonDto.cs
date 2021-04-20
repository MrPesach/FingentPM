using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO
{
    [JsonObject(Title = "Product")]
    public class ProductJsonDto
    {
        public string Product { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
    }

    public class ProductRootJsonDto
    {
        public string IndexFilePath { get; set; }
        public List<ProductJsonDto> Products { get; set; }
    }
}
