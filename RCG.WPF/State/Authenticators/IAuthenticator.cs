using System;
using System.Threading.Tasks;
using RCG.CoreApp.Interfaces.Auth;

namespace RCG.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task Login(string username, string password);

        Task<UserSetupResult> UserSetup(string name, string username, string password, string confirmPassword);

        void Logout();
    }
}
