namespace RCG.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RCG.CoreApp.Interfaces.Repositories;
    using RCG.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        private readonly IRepositoryAsync<Products> _productRepository;
        private readonly IRepositoryAsync<ProductMain> _productMainRepository;
        public ProductRepository(IRepositoryAsync<Products> productRepository, IRepositoryAsync<ProductMain> productMainRepository)
        {
            _productRepository = productRepository;
            _productMainRepository = productMainRepository;
        }

        public async Task<List<Products>> GetPagedListAsync(int pageNumber, int pageSize)
        {
            var productList = await _productRepository.GetPagedReponseAsync(pageNumber, pageSize);
            return productList;
        }

        public async Task<ProductMain> AddProductMainAsync(ProductMain productMain)
        {
            var savedProductMain = await _productMainRepository.AddAsync(productMain);
            return savedProductMain;
        }

        public async Task<bool> AddProductAsync(List<Products> productList)
        {
            var success = await _productRepository.AddRangeAsync(productList);
            return success;
        }
    }
}
