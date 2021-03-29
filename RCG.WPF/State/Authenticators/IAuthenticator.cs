using System;
using System.Threading.Tasks;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Interfaces.User;

namespace RCG.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task Login(string username, string password);

        Task<UserSetupResult> UserSetup(UserSetupDto userSetupDto);

        void Logout();
    }
}
