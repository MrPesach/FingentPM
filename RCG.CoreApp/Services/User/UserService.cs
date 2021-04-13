using System.Collections.Generic;
using System.Threading.Tasks;
using RCG.CoreApp.AppResources;
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

            if (hashPassword != userAccount.PasswordHash)
            {
                throw new InvalidPasswordException(username, password);
            }

            return userAccount;
        }

        public async Task<UserSetupDto> UserSetup(UserSetupDto userSetupDto)
        {
            bool isValid = true;
            string message = string.Empty;
            if (string.IsNullOrWhiteSpace(userSetupDto.Name))
            {
                isValid = false;
                message = "Please enter Name.";
            }
            else if (string.IsNullOrWhiteSpace(userSetupDto.Username))
            {
                isValid = false;
                message = "Please enter Username";
            }
            else if (userSetupDto.Name.Length < 3 || userSetupDto.Name.Length > 20)
            {
                isValid = false;
                message = "Name should have a minimum length of 3 and maximum length of 20 characters.";
            }

            else if (userSetupDto.Username.Length < 5 || userSetupDto.Username.Length > 10)
            {
                isValid = false;
                message = "Username should have a minimum length of 5 and maximum length of 10 characters.";
            }
            else if (userSetupDto.Password.Length < 5 || userSetupDto.Password.Length > 10)
            {
                isValid = false;
                message = "Password should have a minimum length of 5 and maximum length of 10 characters.";
            }
            else if (userSetupDto.Password != userSetupDto.ConfirmPassword)
            {
                isValid = false;
                message = Resource.PasswordNotMatchMsg;
            }

            if (isValid)
            {
                Users usernameAccount = await _userRepository.GetByUsernameAsync(userSetupDto.UserId, userSetupDto.Username);

                if (usernameAccount != null)
                {
                    isValid = false;
                    message = "Username already exists.";
                }

                else
                {
                    string hashedPassword = SecurityHelper.HashPassword(userSetupDto.Password);

                    if (userSetupDto.UserId.HasValue)
                    {
                        Users user = new Users()
                        {
                            Id = userSetupDto.UserId.Value,
                            Name = userSetupDto.Name.Trim(),
                            Username = userSetupDto.Username.Trim(),
                            PasswordHash = hashedPassword,
                            LastModifiedBy = userSetupDto.LastModifiedBy,
                            LastModifiedOn = _dateTimeService.NowUtc,
                            IsAdmin = false
                        };

                        await _userRepository.UpdateAsync(user);
                        isValid = true;
                        message = Resource.UserAccountUpdated;
                    }
                    else
                    {
                        Users user = new Users()
                        {
                            Name = userSetupDto.Name.Trim(),
                            Username = userSetupDto.Username.Trim(),
                            PasswordHash = hashedPassword,
                            CreatedOn = _dateTimeService.NowUtc,
                            IsAdmin = false
                        };

                        await _userRepository.InsertAsync(user);
                        isValid = true;
                        message = Resource.UserAccountSaved;
                    }
                }

            }
            UserSetupDto result = new UserSetupDto
            {
                IsValid = isValid,
                Message = message
            };

            return result;
        }
    }
}
