using System.Windows.Input;
using RCG.CoreApp.Interfaces.User;
using RCG.WPF.Commands;
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

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IProductManagerViewModelFactory viewModelFactory, IAuthenticator authenticator, IUserService authenticationService)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _authenticationService = authenticationService;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            //UpdateCurrentViewModelCommand.Execute(ViewType.Login);

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

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
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
