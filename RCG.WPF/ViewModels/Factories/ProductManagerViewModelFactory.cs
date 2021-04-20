using System;
using RCG.WPF.State.Navigators;

namespace RCG.WPF.ViewModels.Factories
{
    public class ProductManagerViewModelFactory : IProductManagerViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<ProductsViewModel> _productsViewModel;
        private readonly CreateViewModel<UserSetupViewModel> _usersetupViewModel;
        public ProductManagerViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<ProductsViewModel> productsViewModel, CreateViewModel<UserSetupViewModel> usersetupViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _productsViewModel = productsViewModel;
            _usersetupViewModel = usersetupViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Products:
                    return _productsViewModel();
                case ViewType.UserSetup:
                    return _usersetupViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
