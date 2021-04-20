using Microsoft.EntityFrameworkCore.Storage;
using RCG.Domain.Entities;
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

        Task<T> GetByIdAsync(long id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedReponseAsync(
            int pageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null);

        Task<T> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entityList);

        Task UpdateAsync(T entity, object key);

        Task<bool> DeleteAsync(T entity);

        Task BulkDeleteAsync(List<T> entityList);

        IQueryable<T> GetQuery(
                                out int totalCount,
                                Expression<Func<T, bool>> filter = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                bool enablePaging = false,
                                int curPage = 0,
                                int countPerPage = 10,
                                string includeProperties = "");

        IDbContextTransaction Transaction();
    }
}