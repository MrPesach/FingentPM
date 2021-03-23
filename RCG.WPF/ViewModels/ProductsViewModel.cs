
using RCG.CoreApp.Interfaces.Product;
using RCG.Domain.Entities;
using RCG.WPF.Commands;
using RCG.WPF.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductService _productService;

        public ICommand ImportPriceListCommand { get; }

        public ProductsViewModel(
            IProductService productService,
            ImportPriceListViewModel importPriceListViewModel,
            IDialogService dialogService)
        {
            this._productService = productService;
            this.ImportPriceListCommand = new ImportPriceListCommand(this, _productService, dialogService, importPriceListViewModel);
            this.InitialLoad();
        }

        private ObservableCollection<Products> _productList;

        public ObservableCollection<Products> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        private async void InitialLoad()
        {
            var productList = await this._productService.GetPagedProductList(1, 10);
            this.ProductList = new ObservableCollection<Products>(productList);
        }
    }
}
