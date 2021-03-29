using System;
using System.Threading.Tasks;
using RCG.CoreApp.DTO;
using RCG.CoreApp.Interfaces.Auth;
using RCG.Domain.Entities;
using RCG.WPF.State.Accounts;

namespace RCG.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthService _authenticationService;
        private readonly IUserStore _userStore;

        public Authenticator(IAuthService authenticationService, IUserStore userStore)
        {
            _authenticationService = authenticationService;
            _userStore = userStore;
        }

        public Users IsAuthenticated 
        {
            get 
            { 
                return _userStore.IsAuth; 
            }
            private set
            {
                _userStore.IsAuth = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => IsAuthenticated != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {
            IsAuthenticated = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            IsAuthenticated = null;
        }

        public async Task<UserSetupResult> UserSetup(UserSetupDto userSetupDto)
        {
            return await _authenticationService.UserSetup(userSetupDto);
        }
    }
}
