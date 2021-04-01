using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Exceptions;
using RCG.CoreApp.Helpers;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.CoreApp.Interfaces.Shared;
using RCG.CoreApp.Interfaces.User;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeService _dateTimeService;
        public UserService(IUserRepository userRepository, IDateTimeService dateTimeService)
        {
            _userRepository = userRepository;
            _dateTimeService = dateTimeService;
        }

        public async Task<List<Users>> GetNonAdminListAsync()
        {
            List<Users> users = await _userRepository.GetNonAdminListAsync();
            return users;
        }
        
        public async Task<Users> GetNonAdminUserAsync()
        {
            return await _userRepository.GetNonAdminUserAsync();
        }

        public async Task<Users> Login(string username, string password)
        {
            Users userAccount = await _userRepository.GetByUsernameAsync(null, username);

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

        ////public async Task<UserSetupResult> UserSetup(long? id, string name, string username, string password, string confirmPassword)
        ////{
        ////    UserSetupResult result = UserSetupResult.Success;

        ////    if (password != confirmPassword)
        ////    {
        ////        result = UserSetupResult.PasswordsDoNotMatch;
        ////    }
        ////    if (password.Length < 5)
        ////    {
        ////        result = UserSetupResult.PasswordLength;
        ////    }

        ////    Users usernameAccount = await _userRepository.GetByUsernameAsync(username);
        ////    if (usernameAccount != null)
        ////    {
        ////        result = UserSetupResult.UsernameAlreadyExists;
        ////    }

        ////    if (result == UserSetupResult.Success)
        ////    {
        ////        string hashedPassword = SecurityHelper.HashPassword(password);

        ////        Users user = new Users()
        ////        {
        ////            Name = name,
        ////            Username = username,
        ////            PasswordHash = hashedPassword,
        ////            CreatedOn = _dateTimeService.NowUtc,
        ////            IsAdmin = false
        ////        };

        ////        await _userRepository.InsertAsync(user);
        ////    }

        ////    return result;
        ////}

        public async Task<UserSetupResult> UserSetup(UserSetupDto userSetupDto)
        {
            UserSetupResult result = UserSetupResult.Success;

            if (userSetupDto.Username.Length < 5)
            {
                result = UserSetupResult.UsernameLength;
            }

            if (userSetupDto.Password != userSetupDto.ConfirmPassword)
            {
                result = UserSetupResult.PasswordsDoNotMatch;
            }
            if (userSetupDto.Password.Length < 5)
            {
                result = UserSetupResult.PasswordLength;
            }

            Users usernameAccount = await _userRepository.GetByUsernameAsync(userSetupDto.UserId, userSetupDto.Username);

            if (usernameAccount != null)
            {
                result = UserSetupResult.UsernameAlreadyExists;
            }

            if (result == UserSetupResult.Success)
            {
                string hashedPassword = SecurityHelper.HashPassword(userSetupDto.Password);

                if (userSetupDto.UserId != null)
                {
                    Users user = new Users()
                    {
                        Name = userSetupDto.Name,
                        Username = userSetupDto.Username,
                        PasswordHash = hashedPassword,
                        LastModifiedBy = userSetupDto.LastModifiedBy,
                        LastModifiedOn = _dateTimeService.NowUtc,
                        IsAdmin = false
                    };

                    await _userRepository.UpdateAsync(user);
                }
                else
                {
                    Users user = new Users()
                    {
                        Name = userSetupDto.Name,
                        Username = userSetupDto.Username,
                        PasswordHash = hashedPassword,
                        CreatedOn = _dateTimeService.NowUtc,
                        IsAdmin = false
                    };

                    await _userRepository.InsertAsync(user);
                }
            }

            return result;
        }

        public UserSetupDto ValidateUserSave(UserSetupDto userSetupDto)
        {
            bool isValid = true;
            var messageList = new List<string>();
            if (string.IsNullOrEmpty(userSetupDto.Name))
            {
                messageList.Add("Please enter Name");
                isValid = false;
            }

            if (string.IsNullOrEmpty(userSetupDto.Password))
            {
                messageList.Add("Please enter Password");
                isValid = false;
            }
            if (string.IsNullOrEmpty(userSetupDto.Password))
            {
                messageList.Add("Please enter Password");
                isValid = false;
            }
            //userSetupDto.IsValid = isValid;
            return userSetupDto;
        }
    }
}
