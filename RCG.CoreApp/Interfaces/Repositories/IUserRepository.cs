using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<Users>> GetListAsync();

        Task<List<Users>> GetNonAdminListAsync();

        Task<Users> GetNonAdminUserAsync();

        Task<Users> GetByIdAsync(long id);

        Task<Users> GetByUsernameAsync(long? id, string username);

        Task<long> InsertAsync(Users user);

        Task UpdateAsync(Users user);

        Task DeleteAsync(Users user);
    }
}