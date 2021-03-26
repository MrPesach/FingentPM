using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<Users>> GetListAsync();

        Task<List<Users>> GetNonAdminListAsync();

        Task<Users> GetByIdAsync(long id);

        Task<Users> GetByUsernameAsync(string username);

        Task<Users> GetByUsernameandIdAsync(long id, string username);

        Task<long> InsertAsync(Users user);

        Task UpdateAsync(Users user);

        Task DeleteAsync(Users user);
    }
}