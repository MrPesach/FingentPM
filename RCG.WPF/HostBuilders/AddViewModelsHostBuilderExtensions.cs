using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RCG.CoreApp.Interfaces.Product;
using RCG.WPF.Services;
using RCG.WPF.State.Authenticators;
using RCG.WPF.State.Navigators;
using RCG.WPF.ViewModels;
using RCG.WPF.ViewModels.Factories;

namespace RCG.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient(CreateProductsViewModel);
                services.AddTransient<MainViewModel>();
                services.AddTransient<ImportPriceListViewModel>();
                services.AddTransient<AddProductViewModel>();
                services.AddTransient<AlertViewModel>();

                services.AddSingleton<CreateViewModel<ProductsViewModel>>(services => () => services.GetRequiredService<ProductsViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<UserSetupViewModel>>(services => () => CreateRegisterViewModel(services));

                services.AddSingleton<IProductManagerViewModelFactory, ProductManagerViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<ProductsViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<UserSetupViewModel>>();
            });

            return host;
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<ProductsViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<UserSetupViewModel>>());
        }

        private static UserSetupViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new UserSetupViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }

        private static ProductsViewModel CreateProductsViewModel(IServiceProvider services)
        {
            return new ProductsViewModel(services.GetRequiredService<IProductService>(),
                services.GetRequiredService<ImportPriceListViewModel>(),
                services.GetRequiredService<IDialogService>(),
                services.GetRequiredService<AddProductViewModel>(),
                services.GetRequiredService<AlertViewModel>());
        }
    }
}
