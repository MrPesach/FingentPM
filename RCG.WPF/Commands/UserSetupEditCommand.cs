using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.User;
using RCG.WPF.DialogServices;
using RCG.WPF.State.Authenticators;
using RCG.WPF.ViewModels;

namespace RCG.WPF.Commands
{
    public class UserSetupEditCommand : AsyncCommandBase
    {
        private readonly UserSetupEditViewModel _usersetupEditViewModel;
        private readonly IAuthenticator _authenticator;

        public UserSetupEditCommand(UserSetupEditViewModel usersetupEditViewModel, IAuthenticator authenticator)
        {
            _usersetupEditViewModel = usersetupEditViewModel;
            _authenticator = authenticator;
            _usersetupEditViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _usersetupEditViewModel.CanUpdate && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _usersetupEditViewModel.ErrorMessage = string.Empty;

            try
            {
                UserSetupDto userSetupDto = new UserSetupDto()
                {
                    UserId = _usersetupEditViewModel.UserId,
                    Name = _usersetupEditViewModel.Name,
                    Username = _usersetupEditViewModel.Username,
                    Password = _usersetupEditViewModel.Password,
                    ConfirmPassword = _usersetupEditViewModel.ConfirmPassword,
                };

                UserSetupResult userSetupResult = await _authenticator.UserSetup(userSetupDto);

                switch (userSetupResult)
                {
                    case UserSetupResult.Success:
                        //var window = (IDialogWindow)parameter;
                        //CloseDialogWithResult(window, EnumMaster.DialogResults.Success.ToString());
                        ///_usersetupRenavigator.Renavigate();
                        break;
                    case UserSetupResult.PasswordsDoNotMatch:
                        _usersetupEditViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case UserSetupResult.EmailAlreadyExists:
                        _usersetupEditViewModel.ErrorMessage = "An account for this email already exists.";
                        break;
                    case UserSetupResult.UsernameAlreadyExists:
                        _usersetupEditViewModel.ErrorMessage = "An account for this username already exists.";
                        break;
                    case UserSetupResult.PasswordLength:
                        _usersetupEditViewModel.ErrorMessage = "Password should have a minimum length of 5 characters.";
                        break;
                    case UserSetupResult.UsernameLength:
                        _usersetupEditViewModel.ErrorMessage = "Username should have a minimum length of 5 characters.";
                        break;
                    default:
                        _usersetupEditViewModel.ErrorMessage = "Unable to Save.";
                        break;
                }
            }
            catch (Exception)
            {
                _usersetupEditViewModel.ErrorMessage = "Unable to Save.";
            }
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserSetupEditViewModel.CanUpdate))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
