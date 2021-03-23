using RCG.CoreApp.DTO;
using RCG.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Product
{
    public interface IProductService
    {
        Task<List<AddProductDto>> GetPagedProductList(int pageNumber, int pageSize, string search = null);

        Task<ProductMainDto> ImportPriceListAsync(string filePath);

        Task<Products> SetProductModelAsync(PriceListDto item);

        Task<ProductMain> AddProductMainAsync(ProductMainDto productMainDto);

        Task<bool> AddProductBulkAsync(List<Products> productList);

        Task<bool> AddProductAsync(PriceListDto priceListDto);

        bool IsNumber(string value);
    }
}
