using RCG.CoreApp.Interfaces.Product;
using RCG.CoreApp.Services.Product;
using RCG.WPF.Services;
using RCG.WPF.ViewModels;
using RCG.WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RCG.WPF.Commands
{
    public class ImportPriceListCommand : AsyncCommandBase
    {
        private readonly ProductsViewModel _productsViewModel;

        private readonly ImportPriceListViewModel _importPriceListViewModel;

        private readonly IProductService _productService;

        private readonly IDialogService _dialogService;

        public ImportPriceListCommand(
            ProductsViewModel productsViewModel,
            IProductService productService,
            IDialogService dialogService,
            ImportPriceListViewModel importPriceListViewModel)
        {
            _productsViewModel = productsViewModel;
            _productService = productService;
            _dialogService = dialogService;
            _importPriceListViewModel = importPriceListViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var result = _dialogService.OpenDialog(_importPriceListViewModel);
        }
    }
}
