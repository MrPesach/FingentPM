using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.Data.DbContexts;

namespace RCG.Data.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AddRangeAsync(List<T> entityList)
        {
            await _dbContext.Set<T>().AddRangeAsync(entityList);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task BulkDeleteAsync(List<T> entityList)
        {
            this._dbContext.Set<T>().RemoveRange(entityList);
            return this._dbContext.SaveChangesAsync();
            ////return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPagedReponseAsync(
            int pageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null)
        {

            return await _dbContext
                .Set<T>()
                .Where(filter)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task UpdateAsync(T entity, object key)
        {
            if (entity == null)
                return null;
            T exist =  _dbContext.Set<T>().Find(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                 _dbContext.SaveChangesAsync();
            }
            return Task.CompletedTask;

            //this._dbContext.Set<T>().Update(entity);
            //return this._dbContext.SaveChangesAsync();

            //// this._dbContext.Set<T>().Update(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
            //this._dbContext.Set<T>().Update(entity);
            ////this._dbContext.Entry(entity).State = EntityState.Modified;
            //return this._dbContext.SaveChangesAsync();
            ///return Task.CompletedTask;
        }

        public IDbContextTransaction Transaction()
        {
            return this._dbContext.Database.BeginTransaction();
        }
    }
}