using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RCG.CoreApp.DTO;
using RCG.CoreApp.Interfaces.Auth;
using RCG.WPF.State.Authenticators;
using RCG.WPF.State.Navigators;
using RCG.WPF.ViewModels;

namespace RCG.WPF.Commands
{
    public class UserSetupCommand : AsyncCommandBase
    {
        private readonly UserSetupViewModel _usersetupViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _usersetupRenavigator;

        public UserSetupCommand(UserSetupViewModel registerViewModel, IAuthenticator authenticator, IRenavigator usersetupRenavigator)
        {
            _usersetupViewModel = registerViewModel;
            _authenticator = authenticator;
            _usersetupRenavigator = usersetupRenavigator;

            _usersetupViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _usersetupViewModel.CanRegister && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _usersetupViewModel.ErrorMessage = string.Empty;

            try
            {
                UserSetupDto userSetupDto = new UserSetupDto()
                {
                    UserId = null,
                    Name = _usersetupViewModel.Name,
                    Username = _usersetupViewModel.Username,
                    Password = _usersetupViewModel.Password,
                    ConfirmPassword = _usersetupViewModel.ConfirmPassword,
                };

                UserSetupResult userSetupResult = await _authenticator.UserSetup(userSetupDto);

                switch (userSetupResult)
                {
                    case UserSetupResult.Success:
                        _usersetupRenavigator.Renavigate();
                        break;
                    case UserSetupResult.PasswordsDoNotMatch:
                        _usersetupViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case UserSetupResult.EmailAlreadyExists:
                        _usersetupViewModel.ErrorMessage = "An account for this email already exists.";
                        break;
                    case UserSetupResult.UsernameAlreadyExists:
                        _usersetupViewModel.ErrorMessage = "An account for this username already exists.";
                        break;
                    case UserSetupResult.PasswordLength:
                        _usersetupViewModel.ErrorMessage = "Password should have a minimum length of 5 characters.";
                        break;
                    case UserSetupResult.UsernameLength:
                        _usersetupViewModel.ErrorMessage = "Username should have a minimum length of 5 characters.";
                        break;
                    default:
                        _usersetupViewModel.ErrorMessage = "Unable to Save.";
                        break;
                }
            }
            catch (Exception)
            {
                _usersetupViewModel.ErrorMessage = "Unable to Save.";
            }
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserSetupViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
