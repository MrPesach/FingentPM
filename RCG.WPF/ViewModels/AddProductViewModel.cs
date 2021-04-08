using RCG.CoreApp.DTO;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.Product;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using RCG.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            this.SaveProductCommand = new RelayCommand(o => this.SaveProductAsync(o), o => this.CanExecuteSave);
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

        private async Task SaveProductAsync(object obj)
        {
            var validatedProduct = this._productService.ValidateProductSave(this.AddProduct, false);
            if (validatedProduct.IsValid)
            {
                var success = await this._productService.AddProductAsync(this.AddProduct);
                if (success)
                {
                    this.ClearAll();
                    var window = (IDialogWindow)obj;
                    CloseDialogWithResult(window, EnumMaster.DialogResults.Success.ToString());
                }
            }
            else
            {
                this.SetErrorMessage(validatedProduct.ValidationMessage);
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
    }
}
