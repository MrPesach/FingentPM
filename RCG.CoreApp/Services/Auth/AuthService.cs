using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.CoreApp.Exceptions;
using RCG.CoreApp.Helpers;
using RCG.CoreApp.Interfaces.Auth;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.CoreApp.Interfaces.Shared;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeService _dateTimeService;
        public AuthService(IUserRepository userRepository, IDateTimeService dateTimeService)
        {
            _userRepository = userRepository;
            _dateTimeService = dateTimeService;
        }

        public async Task<List<Users>> GetNonAdminListAsync()
        {
            List<Users> users = await _userRepository.GetNonAdminListAsync();
            return users;
        }

        public async Task<Users> Login(string username, string password)
        {
            Users userAccount = await _userRepository.GetByUsernameAsync(username);

            if (userAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            string hashPassword = SecurityHelper.HashPassword(password.Trim());
            
            if(hashPassword != userAccount.PasswordHash)
            {
                throw new InvalidPasswordException(username, password);
            }

            return userAccount;
        }

        public async Task<UserSetupResult> UserSetup(string name, string username, string password, string confirmPassword)
        {
            UserSetupResult result = UserSetupResult.Success;

            if (password != confirmPassword)
            {
                result = UserSetupResult.PasswordsDoNotMatch;
            }
            if (password.Length < 5)
            {
                result = UserSetupResult.PasswordLength;
            }

            Users usernameAccount = await _userRepository.GetByUsernameAsync(username);
            if (usernameAccount != null)
            {
                result = UserSetupResult.UsernameAlreadyExists;
            }

            if (result == UserSetupResult.Success)
            {
                string hashedPassword = SecurityHelper.HashPassword(password);

                Users user = new Users()
                {
                    Name = name,
                    Username = username,
                    PasswordHash = hashedPassword,
                    CreatedOn = _dateTimeService.NowUtc,
                    IsAdmin = false
                };

                await _userRepository.InsertAsync(user);
            }

            return result;
        }
    }
}
