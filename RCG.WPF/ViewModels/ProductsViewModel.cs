
using RCG.CoreApp.AppResources;
using RCG.CoreApp.DTO;
using RCG.CoreApp.DTO.Common;
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
        public ICommand FirstOrLastCommand { get; }
        public ICommand NextOrPrevCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductsViewModel(
            IProductService productService,
            ImportPriceListViewModel importPriceListViewModel,
            IDialogService dialogService,
            AddProductViewModel addProductViewModel,
            AlertViewModel alertViewModel)
        {
            ////WindowHeight = Convert.ToInt32(Resource.HeightProductsView);
            ////WindowWidth = Convert.ToInt32(Resource.WidthProductsView);

            this._productService = productService;
            this._dialogService = dialogService;
            this._addProductViewModel = addProductViewModel;
            this._alertViewModel = alertViewModel;
            this._importPriceListViewModel = importPriceListViewModel;

            this.ImportPriceListCommand = new RelayCommand(obj => this.ImportProductList(), obj => true);
            this.SearchCommand = new RelayCommand(obj => this.Search(), obj => true);
            this.PaginationCommand = new RelayCommand(obj => this.PaginationClick(obj), obj => true);
            this.FirstOrLastCommand = new RelayCommand(obj => this.FirstOrLast(obj), obj => true);
            this.NextOrPrevCommand = new RelayCommand(obj => this.FirstOrLast(obj), obj => true);
            this.AddProductCommand = new RelayCommand(obj => this.AddProduct(), obj => true);
            this.EditProductCommand = new RelayCommand(obj => this.EditProduct(obj), obj => true);
            this.DeleteProductCommand = new RelayCommand(obj => this.DeleteProduct(obj), obj => true);
            this.InitialLoad();
        }

        private ObservableCollection<AddProductDto> _productList;
        private string _searchText;
        private ObservableCollection<PaginationButtonDto> _pages;
        private int _pageNumber;
        private bool _isNoRecords;
        private int _totalPages;

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

        public ObservableCollection<AddProductDto> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                this.IsNoRecords = !value.Any();
                OnPropertyChanged(nameof(ProductList));
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.OnPropertyChanged("SearchText"); }
        }

        public ObservableCollection<PaginationButtonDto> Pages
        {
            get { return _pages; }
            set { _pages = value; this.OnPropertyChanged("Pages"); }
        }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; this.OnPropertyChanged("PageNumber"); }
        }

        public bool IsNoRecords
        {
            get { return _isNoRecords; }
            set { _isNoRecords = value; this.OnPropertyChanged("IsNoRecords"); }
        }

        public int TotalPages
        {
            get { return _totalPages; }
            set { _totalPages = value; this.OnPropertyChanged("TotalPages"); }
        }


        private async Task InitialLoad()
        {
            this.PageNumber = 0;
            ////this.SetPages();
            this.SearchText = string.Empty;
            await this.GetProducts();
        }

        private async Task GetProducts()
        {
            var gridResponse = await this._productService.GetPagedProductList(this.PageNumber, 10, this.SearchText);
            this.TotalPages = gridResponse.TotalPages;
            this.SetPages();
            this.ProductList = new ObservableCollection<AddProductDto>(gridResponse.Rows);
        }

        private async void Search()
        {
            this.PageNumber = 0;
            ////this.SetPages();
            await this.GetProducts();
        }

        private void SetPages()
        {
            this.Pages = new ObservableCollection<PaginationButtonDto>();

            var fromPage = this.PageNumber > 1 ? this.PageNumber - 1 : 1;
            fromPage = (this.PageNumber + 1) >= this.TotalPages - 1 ? this.TotalPages - 4 : fromPage;

            var toPage = (fromPage + 4) > this.TotalPages ? this.TotalPages : (fromPage + 4);
            for (int i = fromPage; i <= toPage; i++)
            {
                this.Pages.Add(new PaginationButtonDto { Number = i, IsSelected = this.PageNumber == 0 && i == 1 });
            }
        }

        private async Task PaginationClick(object selectedPageNumber)
        {
            var selectedNumber = (int)selectedPageNumber;
            if (selectedNumber > 0)
            {
                this.PageNumber = selectedNumber - 1;
                await GetProducts();
                var selectedPage = this.Pages.FirstOrDefault(a => a.Number == selectedNumber);
                selectedPage.IsSelected = true;
            }
        }

        private async void FirstOrLast(object selectedButton)
        {
            var firstOrLast = (string)selectedButton;
            int selectedNumber = 0;
            if (firstOrLast == "First")
            {
                selectedNumber = 1;
            }
            else if (firstOrLast == "Last")
            {
                selectedNumber = this.TotalPages;
            }
            else if (firstOrLast == "Prev" && this.PageNumber > 0)
            {
                selectedNumber = this.PageNumber;
            }
            else if (firstOrLast == "Next" && this.PageNumber + 1 < this.TotalPages)
            {
                selectedNumber = this.PageNumber + 2;
            }

            await this.PaginationClick(selectedNumber);
        }

        private async void AddProduct()
        {
            _addProductViewModel.Title = "Add New Product";
            var result = this._dialogService.OpenDialog(_addProductViewModel);
            if (result == EnumMaster.DialogResults.Success.ToString())
            {
                await this.InitialLoad();
                this._dialogService.OpenMessageBox("Add Product", "Product added successfully", EnumMaster.MessageBoxType.Success);
                ////_alertViewModel.IconUri = "/Resources/Images/check-green.png";
                ////_alertViewModel.Title = "Success";
                ////_alertViewModel.Message = "Product added successfully";
                ////this._dialogService.OpenDialog(_alertViewModel);
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
                _addProductViewModel.Title = "Update Product";
                var result = this._dialogService.OpenDialog(this._addProductViewModel);
                if (result == EnumMaster.DialogResults.Success.ToString())
                {
                    await this.InitialLoad();
                    this._dialogService.OpenMessageBox("Update Product", "Product details updated successfully", EnumMaster.MessageBoxType.Success);
                    ////_alertViewModel.IconUri = "/Resources/Images/check-green.png";
                    ////_alertViewModel.Title = "Update Product";
                    ////_alertViewModel.Message = "Product details updated successfully";
                    ////this._dialogService.OpenDialog(_alertViewModel);
                }
            }
        }

        private async void DeleteProduct(object obj)
        {
            if (obj != null)
            {
                var addProductDto = (AddProductDto)obj;

                if (addProductDto.ProductId > 0)
                {
                    var result = this._dialogService.OpenMessageBox("Confirm", "Are you sure to delete the Product", EnumMaster.MessageBoxType.Confirmation);
                    if (result == EnumMaster.DialogResults.Yes)
                    {
                        await this.DeleteProductByIdAsync(addProductDto.ProductId);
                    }
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

        private async Task DeleteProductByIdAsync(long productId)
        {
            bool result = await this._productService.DeleteProductByIdAsync(productId);
            if (result)
            {
                this._dialogService.OpenMessageBox("Success", "Product deleted successfully.", EnumMaster.MessageBoxType.Success);
                this.ProductList.Remove(ProductList.Single(s => s.ProductId == productId));
                this.IsNoRecords = !this.ProductList.Any();
            }
        }
    }
}
