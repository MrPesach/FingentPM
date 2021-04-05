using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.CoreApp.DTO.User;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Interfaces.User
{
    public enum UserSetupResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
        PasswordLength,
        UsernameLength
    }

    public interface IUserService
    {
        Task<List<Users>> GetNonAdminListAsync();

        Task<Users> GetNonAdminUserAsync();

        Task<Users> Login(string username, string password);

        Task<UserSetupDto> UserSetup(UserSetupDto userSetupDto);
    }
}
