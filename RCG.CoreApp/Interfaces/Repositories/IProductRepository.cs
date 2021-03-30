using RCG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Products>> GetPagedListAsync(
            int pageNumber, int pageSize,
            Expression<Func<Products, bool>> filter = null);

        Task<ProductMain> AddProductMainAsync(ProductMain productMain);

        Task<bool> AddProductBulkAsync(List<Products> productList, List<Products> productListForDelete = null);
        Task<bool> AddProductAsync(Products product);
        bool IsProductExist(string styleName);
        Task<List<Products>> GetProductsBySkuListAync(List<string> skuList);
        Task<bool> DeleteProductByIdAsync(long productId);
        IQueryable<Products> GetQuery(out int totalCount, int pageNumber, int pageSize, Expression<Func<Products, bool>> filter = null);
    }
}
