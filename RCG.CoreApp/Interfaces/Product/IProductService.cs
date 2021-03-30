using RCG.CoreApp.DTO;
using RCG.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Product
{
    public interface IProductService
    {
        Task<GridResponseDto<AddProductDto>> GetPagedProductList(int pageNumber, int pageSize, string search = null);

        Task<ProductMainDto> ImportPriceListAsync(string filePath);

        Task<Products> SetProductModelAsync(AddProductDto item);

        Task<ProductMain> AddProductMainAsync(ProductMainDto productMainDto);

        Task<bool> AddProductBulkAsync(List<Products> productList, List<Products> productListForDelete = null);

        Task<bool> AddProductAsync(AddProductDto priceListDto);

        bool IsNumber(string value);

        bool IsProductExist(string styleName);

        AddProductDto ValidateProductSave(AddProductDto addProductDto, bool isImport);

        Task<List<Products>> GetProductsBySkuListAync(List<string> skuList);
        Task<bool> CreateCSVAsync(List<AddProductDto> failedProductList, string filePath);
        bool ValidateCSV(string fileName);
        Task<bool> DeleteProductByIdAsync(long productId);
    }
}
