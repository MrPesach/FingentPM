using System;
using RCG.WPF.State.Navigators;

namespace RCG.WPF.ViewModels.Factories
{
    public class ProductManagerViewModelFactory : IProductManagerViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<ProductsViewModel> _productsViewModel;
        public ProductManagerViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<ProductsViewModel> productsViewMode)
        {
            _createLoginViewModel = createLoginViewModel;
            _productsViewModel = productsViewMode;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Products:
                    return _productsViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
