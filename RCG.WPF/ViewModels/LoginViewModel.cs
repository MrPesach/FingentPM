using System;
using System.Windows.Input;
using RCG.CoreApp.AppResources;
using RCG.WPF.Commands;
using RCG.WPF.State.Authenticators;
using RCG.WPF.State.Navigators;

namespace RCG.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private int _windowWidth;
        public int WindowWidth
        {
            get { return _windowWidth; }
            set
            {
                _windowWidth = value;
                OnPropertyChanged(Resource.WindowWidth);
            }
        }

        private int _windowHeight;
        public int WindowHeight
        {
            get { return _windowHeight; }
            set
            {
                _windowHeight = value;
                OnPropertyChanged(Resource.WindowHeight);
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
                OnPropertyChanged(nameof(CanLogin));
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
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);

            this.Username = "superadmin";
            this.Password = "password";

            WindowHeight = Convert.ToInt32(Resource.HeightLoginView);
            WindowWidth = Convert.ToInt32(Resource.WidthLoginView);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
