using System;
using System.Threading.Tasks;
using RCG.CoreApp.DTO;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Interfaces.User;
using RCG.Domain.Entities;
using RCG.WPF.State.Accounts;

namespace RCG.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IUserService _authenticationService;
        private readonly IUserStore _userStore;

        public Authenticator(IUserService authenticationService, IUserStore userStore)
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

        public async Task<UserSetupDto> UserSetup(UserSetupDto userSetupDto)
        {
            return await _authenticationService.UserSetup(userSetupDto);
        }
    }
}
