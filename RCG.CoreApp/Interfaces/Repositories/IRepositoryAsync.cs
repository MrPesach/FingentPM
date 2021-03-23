using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedReponseAsync(
            int pageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null);

        Task<T> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entityList);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}