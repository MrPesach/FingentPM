namespace RCG.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RCG.CoreApp.DTO;
    using RCG.CoreApp.Interfaces.Repositories;
    using RCG.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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

        public async Task<List<Products>> GetPagedListAsync(
            int pageNumber, int pageSize,
            Expression<Func<Products, bool>> filter = null)
        {
            var productList = await _productRepository.GetPagedReponseAsync(pageNumber, pageSize, filter);
            return productList;
        }

        public async Task<ProductMain> AddProductMainAsync(ProductMain productMain)
        {
            var savedProductMain = await _productMainRepository.AddAsync(productMain);
            return savedProductMain;
        }

        public async Task<bool> AddProductBulkAsync(List<Products> productList)
        {
            var success = await _productRepository.AddRangeAsync(productList);
            return success;
        }

        public async Task<bool> AddProductAsync(Products product)
        {
            if (product.Id > 0)
            {
                await _productRepository.UpdateAsync(product);
            }
            else
            {
                await _productRepository.AddAsync(product);
            }

            return true;
        }
    }
}
