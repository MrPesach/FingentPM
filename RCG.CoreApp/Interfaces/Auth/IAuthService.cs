using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Interfaces.Auth
{
    public enum UserSetupResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
        PasswordLength
    }

    public interface IAuthService
    {
        Task<List<Users>> GetNonAdminListAsync();
        Task<Users> Login(string username, string password);

        Task<UserSetupResult> UserSetup(string name, string username, string password, string confirmPassword);
    }
}
