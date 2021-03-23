using RCG.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Products>> GetPagedListAsync(int pageNumber, int pageSize);

        Task<ProductMain> AddProductMainAsync(ProductMain productMain);

        Task<bool> AddProductAsync(List<Products> productList);
    }
}
