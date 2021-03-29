using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RCG.CoreApp.DTO;
using RCG.CoreApp.DTO.User;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.User;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using RCG.WPF.State.Accounts;

namespace RCG.WPF.ViewModels
{
    public class UserSetupEditViewModel : DialogViewModelBase<string>
    {
        public ICommand SaveUserCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly IUserService _authService;
        private readonly IUserStore _userStore;

        public UserSetupEditViewModel(IUserService authService, IUserStore userStore)
        {
            _authService = authService;
            _userStore = userStore;
            this.SaveUserCommand = new RelayCommand(o => this.SaveUser(o), o => this.CanExecuteSave);
            this.CancelCommand = new RelayCommand(o => this.CloseDialog(o), o => true);
            this.ClearAll();
        }

        private UserSetupDto _addUser;

        public UserSetupDto AddUser
        {
            get { return _addUser; }
            set { _addUser = value; this.OnPropertyChanged("AddUser"); }
        }

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public bool CanExecuteSave => this.AddUser != null && !string.IsNullOrEmpty(AddUser.Name) && !string.IsNullOrEmpty(AddUser.Username) && !string.IsNullOrEmpty(AddUser.Password) && !string.IsNullOrEmpty(AddUser.ConfirmPassword);

        private async void SaveUser(object obj)
        {
            ////var validatedProduct = this._authService.ValidateProductUser(this.AddUser, false);
            ////if (validatedProduct.IsValid)
            ////{
            ////    var success = await this._authService.UserSetup(this.AddUser);
            ////    if (success)
            ////    {
            ////        this.ClearAll();
            ////        var window = (IDialogWindow)obj;
            ////        CloseDialogWithResult(window, EnumMaster.DialogResults.Success.ToString());
            ////    }
            ////}
            ////else
            ////{
            ////    this.SetErrorMessage(validatedProduct.ValidationMessage);
            ////}
        }

        private void CloseDialog(object obj)
        {
            this.ClearAll();
            var window = (IDialogWindow)obj;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Cancelled.ToString());
        }

        private void ClearAll()
        {
            this.AddUser = new UserSetupDto();
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        private void SetErrorMessage(string value)
        {
            ErrorMessageViewModel.Message = value;
        }
    }
}
