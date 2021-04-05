using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Interfaces.User;
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

                UserSetupDto userSetupDtoResult = await _authenticator.UserSetup(userSetupDto);

                if (userSetupDtoResult.IsValid == true)
                {
                    _usersetupRenavigator.Renavigate();
                }
                else
                {
                    _usersetupViewModel.ErrorMessage = userSetupDtoResult.Message;
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
