
using RCG.CoreApp.DTO;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.Product;
using RCG.Domain.Entities;
using RCG.WPF.Commands;
using RCG.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductService _productService;

        private readonly IDialogService _dialogService;

        private readonly AddProductViewModel _addProductViewModel;

        private readonly AlertViewModel _alertViewModel;

        private readonly ImportPriceListViewModel _importPriceListViewModel;

        public ICommand ImportPriceListCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand PaginationCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }

        public ProductsViewModel(
            IProductService productService,
            ImportPriceListViewModel importPriceListViewModel,
            IDialogService dialogService,
            AddProductViewModel addProductViewModel,
            AlertViewModel alertViewModel)
        {
            this._productService = productService;
            this._dialogService = dialogService;
            this._addProductViewModel = addProductViewModel;
            this._alertViewModel = alertViewModel;
            this._importPriceListViewModel = importPriceListViewModel;

            this.ImportPriceListCommand = new RelayCommand(obj => this.ImportProductList(), obj => true);
            this.SearchCommand = new RelayCommand(obj => this.Search(), obj => true);
            this.PaginationCommand = new RelayCommand(obj => this.PaginationClick(obj), obj => true);
            this.AddProductCommand = new RelayCommand(obj => this.AddProduct(), obj => true);
            this.EditProductCommand = new RelayCommand(obj => this.EditProduct(obj), obj => true);
            this.InitialLoad();
        }

        private ObservableCollection<AddProductDto> _productList;
        private string _searchText;
        private ObservableCollection<int> _pages;
        private int _pageNumber;

        public ObservableCollection<AddProductDto> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.OnPropertyChanged("SearchText"); }
        }

        public ObservableCollection<int> Pages
        {
            get { return _pages; }
            set { _pages = value; this.OnPropertyChanged("Pages"); }
        }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; this.OnPropertyChanged("PageNumber"); }
        }


        private async Task InitialLoad()
        {
            this.PageNumber = 1;
            this.SetPages();
            this.SearchText = string.Empty;
            await this.GetProducts();
        }

        private async Task GetProducts()
        {
            var productList = await this._productService.GetPagedProductList(this.PageNumber, 10, this.SearchText);
            this.ProductList = new ObservableCollection<AddProductDto>(productList);
        }

        private async void Search()
        {
            this.PageNumber = 1;
            this.SetPages();
            await this.GetProducts();
        }

        private void SetPages()
        {
            this.Pages = new ObservableCollection<int>();
            var endingPageNumber = this.PageNumber + 4;
            for (int i = this.PageNumber; i <= endingPageNumber; i++)
            {
                Pages.Add(i);
            }
        }

        private async void PaginationClick(object selectedPageNumber)
        {
            this.PageNumber = (int)selectedPageNumber;
            await GetProducts();
            this.SetPages();
        }

        private async void AddProduct()
        {
            var result = this._dialogService.OpenDialog(_addProductViewModel);
            if (result == EnumMaster.DialogResults.Success.ToString())
            {
                await this.InitialLoad();
                _alertViewModel.IconUri = "/Resources/Images/check-green.png";
                _alertViewModel.Title = "Success";
                _alertViewModel.Message = "Product Saved Successfully";
                this._dialogService.OpenDialog(_alertViewModel);
            }
        }

        private async void EditProduct(object obj)
        {
            if (obj != null)
            {
                var addProductDto = (AddProductDto)obj;
                this._addProductViewModel.AddProduct = new AddProductDto
                {
                    ProductId = addProductDto.ProductId,
                    Style = addProductDto.Style,
                    AvailableLength = addProductDto.AvailableLength,
                    AvrageWeight = addProductDto.AvrageWeight,
                    Price = addProductDto.Price,
                };

                var result = this._dialogService.OpenDialog(this._addProductViewModel);
                if (result == EnumMaster.DialogResults.Success.ToString())
                {
                    await this.InitialLoad();
                    _alertViewModel.Title = "Update Product";
                    _alertViewModel.Message = "Product Updated Successfully";
                    this._dialogService.OpenDialog(_alertViewModel);
                }
            }
        }

        private async void ImportProductList()
        {
            var result = _dialogService.OpenDialog(_importPriceListViewModel);
            if (result != EnumMaster.DialogResults.Cancelled.ToString())
            {
                await this.InitialLoad();
            }
        }
    }
}
