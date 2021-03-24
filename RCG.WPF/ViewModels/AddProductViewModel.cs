using RCG.CoreApp.DTO;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.Product;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using RCG.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class AddProductViewModel : DialogViewModelBase<string>
    {
        public ICommand SaveProductCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly IProductService _productService;
        private readonly IUserStore _userStore;

        public AddProductViewModel(IProductService productService, IUserStore userStore)
        {
            _productService = productService;
            _userStore = userStore;
            this.SaveProductCommand = new RelayCommand(o => this.SaveProduct(o), o => this.CanExecuteSave);
            this.CancelCommand = new RelayCommand(o => this.CloseDialog(o), o => true);
            this.ClearAll();
        }

        private AddProductDto _addProduct;

        public AddProductDto AddProduct
        {
            get { return _addProduct; }
            set { _addProduct = value; this.OnPropertyChanged("AddProduct"); }
        }

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public bool CanExecuteSave => this.AddProduct != null && !string.IsNullOrEmpty(AddProduct.Style) && !string.IsNullOrEmpty(AddProduct.Price);

        private async void SaveProduct(object obj)
        {
            if (this.ValidateProductSave())
            {
                var priceListDto = new PriceListDto
                {
                    ProductId = this.AddProduct.ProductId,
                    AvailableLength = this.AddProduct.AvailableLength,
                    AvrageWeight = this.AddProduct.AvrageWeight,
                    Price = this.AddProduct.Price,
                    Style = this.AddProduct.Style,
                    User = _userStore.IsAuth.Username,
                };

                var success = await this._productService.AddProductAsync(priceListDto);
                if (success)
                {
                    this.ClearAll();
                    var window = (IDialogWindow)obj;
                    CloseDialogWithResult(window, EnumMaster.DialogResults.Success.ToString());
                }
            }
        }

        private void CloseDialog(object obj)
        {
            this.ClearAll();
            var window = (IDialogWindow)obj;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Cancelled.ToString());
        }

        private void ClearAll()
        {
            this.AddProduct = new AddProductDto();
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        private void SetErrorMessage(string value)
        {
            ErrorMessageViewModel.Message = value;
        }

        private bool ValidateProductSave()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(this.AddProduct.Style))
            {
                this.SetErrorMessage("Please enter Style Name");
                isValid = false;
            }
            else if (!string.IsNullOrEmpty(this.AddProduct.Style) &&
                this.AddProduct.ProductId == 0 &&
                _productService.IsProductExist(this.AddProduct.Style))
            {
                this.SetErrorMessage("Style Name already exist");
                isValid = false;
            }
            else if (!string.IsNullOrEmpty(this.AddProduct.AvailableLength)
                && !_productService.IsNumber(this.AddProduct.AvailableLength))
            {
                this.SetErrorMessage("Please enter a valid Available Length");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(this.AddProduct.Price)
               || !_productService.IsNumber(this.AddProduct.Price))
            {
                this.SetErrorMessage("Please enter a valid Price");
                isValid = false;
            }
            else if (!string.IsNullOrEmpty(this.AddProduct.AvrageWeight)
                && !_productService.IsNumber(this.AddProduct.AvrageWeight))
            {
                this.SetErrorMessage("Please enter a valid Average Weight");
                isValid = false;
            }

            return isValid;
        }
    }
}
