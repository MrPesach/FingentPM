using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Interfaces.Auth
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthService
    {
        Task<List<Users>> GetNonAdminListAsync();
        Task<Users> Login(string username, string password);

        Task<RegistrationResult> Register(string name, string username, string password, string confirmPassword);
    }
}
