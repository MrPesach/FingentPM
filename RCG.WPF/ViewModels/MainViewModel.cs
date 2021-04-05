using System;
using System.Windows.Input;
using RCG.CoreApp.Interfaces.User;
using RCG.WPF.Commands;
using RCG.WPF.Services;
using RCG.WPF.State.Accounts;
using RCG.WPF.State.Authenticators;
using RCG.WPF.State.Navigators;
using RCG.WPF.ViewModels.Factories;

namespace RCG.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        ////private int _windowWidth;
        ////public int WindowWidth
        ////{
        ////    get { return _windowWidth; }
        ////    set
        ////    {
        ////        _windowWidth = value;
        ////        RaisePropertyChanged(Resource.WindowWidth);
        ////    }
        ////}

        ////private int _windowHeight;
        ////public int WindowHeight
        ////{
        ////    get { return _windowHeight; }
        ////    set
        ////    {
        ////        _windowHeight = value;
        ////        RaisePropertyChanged(Resource.WindowHeight);
        ////    }
        ////}

        private readonly IProductManagerViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly IUserService _authenticationService;
        private readonly IDialogService _dialogService;
        private readonly UserSetupEditViewModel _userSetupEditViewModel;
        private readonly IndexPathViewModel _indexPathViewModel;
        private readonly IUserStore _userStore;
        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand UserSettingsCommand { get; }
        public ICommand ChangeIndexPathCommand { get; }

        public MainViewModel(
            INavigator navigator,
            IProductManagerViewModelFactory viewModelFactory,
            IAuthenticator authenticator,
            IUserService authenticationService,
            IDialogService dialogService,
            UserSetupEditViewModel userSetupEditViewModel,
            IUserStore userStore,
            IndexPathViewModel indexPathViewModel)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _authenticationService = authenticationService;
            this._userStore = userStore;
            this._dialogService = dialogService;
            this._userSetupEditViewModel = userSetupEditViewModel;
            this._indexPathViewModel = indexPathViewModel;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            this.UserSettingsCommand = new RelayCommand(a => this.UserSettings());
            this.ChangeIndexPathCommand = new RelayCommand(a => this.ChangeIndexPath());
            ////UpdateCurrentViewModelCommand.Execute(ViewType.Login);

            ////WindowHeight = Convert.ToInt32(Resource.HeightProductsView);
            ////WindowWidth = Convert.ToInt32(Resource.WidthProductsView);

            var userList = _authenticationService.GetNonAdminListAsync();
            if (userList.Result.Count > 0)
            {
                UpdateCurrentViewModelCommand.Execute(ViewType.Login);
                ////WindowHeight = Convert.ToInt32(Resource.HeightLoginView);
                ////WindowWidth = Convert.ToInt32(Resource.WidthLoginView);
            }
            else
            {
                UpdateCurrentViewModelCommand.Execute(ViewType.UserSetup);
            }

        }

        private string _loggedUserName;
        private string _loggedUserFirstLetter;

        public string LoggedUserName
        {
            get { return _loggedUserName; }
            set
            {
                _loggedUserName = value;
                this.LoggedUserFirstLetter = value[0].ToString().ToUpper();
                this.OnPropertyChanged("LoggedUserName");
            }
        }


        public string LoggedUserFirstLetter
        {
            get { return _loggedUserFirstLetter; }
            set { _loggedUserFirstLetter = value; this.OnPropertyChanged("LoggedUserFirstLetter"); }
        }

        private void UserSettings()
        {
            _userSetupEditViewModel.Title = "User Settings";
            this._dialogService.OpenDialog(_userSetupEditViewModel);
        }

        private void ChangeIndexPath()
        {
            this._dialogService.OpenDialog(_indexPathViewModel);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            if (IsLoggedIn)
            {
                this.LoggedUserName = this._userStore.IsAuth.Name;
            }
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;
            _authenticator.StateChanged -= Authenticator_StateChanged;

            base.Dispose();
        }
    }
}
