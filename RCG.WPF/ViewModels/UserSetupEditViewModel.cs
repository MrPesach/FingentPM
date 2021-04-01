using System.Windows.Input;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.User;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using RCG.WPF.State.Accounts;
using RCG.WPF.State.Authenticators;

namespace RCG.WPF.ViewModels
{
    public class UserSetupEditViewModel : DialogViewModelBase<string>
    {
        private long _UserId;
        public long UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
                ////OnPropertyChanged(nameof(UserId));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanUpdate));
            }
        }

        public bool CanUpdate => !string.IsNullOrEmpty(Name) &&
            !string.IsNullOrEmpty(Username) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand UpdateUserCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly IAuthenticator _authenticator;
        private readonly IUserStore _userStore;

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public UserSetupEditViewModel(IAuthenticator authenticator, IUserStore userStore)
        {
            ErrorMessageViewModel = new MessageViewModel();

            _authenticator = authenticator;
            _userStore = userStore;
            this.CancelCommand = new RelayCommand(o => this.CloseDialog(o), o => true);
            UpdateUserCommand = new UserSetupEditCommand(this, authenticator);
        }
        private void CloseDialog(object obj)
        {
            var window = (IDialogWindow)obj;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Cancelled.ToString());
        }
        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}