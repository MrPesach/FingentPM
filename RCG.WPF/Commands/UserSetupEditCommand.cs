using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RCG.CoreApp.AppResources;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Enums;
using RCG.WPF.DialogServices;
using RCG.WPF.Services;
using RCG.WPF.State.Authenticators;
using RCG.WPF.ViewModels;

namespace RCG.WPF.Commands
{
    public class UserSetupEditCommand : AsyncCommandBase
    {
        private readonly UserSetupEditViewModel _usersetupEditViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IDialogService _dialogService;

        public UserSetupEditCommand(UserSetupEditViewModel usersetupEditViewModel, IAuthenticator authenticator, IDialogService dialogService)
        {
            _usersetupEditViewModel = usersetupEditViewModel;
            _authenticator = authenticator;
            _dialogService = dialogService;
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

                UserSetupDto userSetupDtoResult = await _authenticator.UserSetup(userSetupDto);

                if (userSetupDtoResult.IsValid == true)
                {
                    var window = (IDialogWindow)parameter;
                    CloseDialogWithResult(window, EnumMaster.DialogResults.Success.ToString());
                    this._dialogService.OpenMessageBox(Resource.ManageUserAccountHeading, userSetupDtoResult.Message, EnumMaster.MessageBoxType.Success);
                }
                else
                {
                    _usersetupEditViewModel.ErrorMessage = userSetupDtoResult.Message;
                }
            }
            catch (Exception)
            {
                _usersetupEditViewModel.ErrorMessage = Resource.UnableUpdate;
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
