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

        public async Task<RegistrationResult> Register(string name, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Users usernameAccount = await _userRepository.GetByUsernameAsync(username);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
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
