using System;
using RCG.Domain.Entities;

namespace RCG.WPF.State.Accounts
{
    public class UserStore : IUserStore
    {
        private Users _isAuth;
        public Users IsAuth
        {
            get
            {
                return _isAuth;
            }
            set
            {
                _isAuth = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
