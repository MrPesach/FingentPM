using RCG.CoreApp.DTO;
using RCG.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Product
{
    public interface IProductService
    {
        Task<List<Products>> GetPagedProductList(int pageNumber, int pageSize);

        Task<ProductMainDto> ImportPriceListAsync(string filePath);

        Task<Products> SetProductModelAsync(PriceListDto item, ProductMainDto productMainDto);

        Task<ProductMain> AddProductMainAsync(ProductMainDto productMainDto);

        Task<bool> AddProductAsync(List<Products> productList);
    }
}
