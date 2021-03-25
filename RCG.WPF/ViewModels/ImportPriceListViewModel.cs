using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using RCG.CoreApp.DTO;
using RCG.CoreApp.DTO.Mapper;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.Product;
using RCG.Domain.Entities;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using RCG.WPF.Services;
using RCG.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class ImportPriceListViewModel : DialogViewModelBase<string>
    {
        public ICommand BrowseFileCommand { get; }
        public ICommand ProceedCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand DownloadCSVCommand { get; }
        private readonly IProductService _productService;
        private readonly IUserStore _userStore;
        private readonly IDialogService _dialogService;

        public ImportPriceListViewModel(
            IProductService productService,
            IUserStore userStore,
            IDialogService dialogService)
        {
            _productService = productService;
            _userStore = userStore;
            _dialogService = dialogService;
            this.ProceedCommand = new RelayCommand(o => this.ProceedFileUpload(), o => this.CanExecute);
            this.BrowseFileCommand = new RelayCommand(o => this.BrowseFile(), o => true);
            this.CancelCommand = new RelayCommand(o => this.Cancel(o), o => true);
            this.DownloadCSVCommand = new RelayCommand(o => this.DownloadCSV(), o => true);
            this.InitialLoad();
        }

        private bool _fileUploadSection;
        private bool _progressBarSection;
        private double _popupHeight;
        private double _progressBarValue;
        private List<AddProductDto> _failedProductList;
        private int _numberOfNew;
        private int _numberOfTotal;
        private int _numberOfUpdated;
        private int _numberOfFiled;
        private bool _isCompleted;
        private bool _inProgress;
        private string _importCompleteImageUri;
        private string _importCompleteMessage;
        private bool _csvHasError;
        private bool _csvHasNoError;

        public bool CanExecute => !string.IsNullOrEmpty(this.FilePath) && !ProgressBarSection;

        public string FilePath { get; set; }

        public bool FileUploadSection
        {
            get { return _fileUploadSection; }
            set
            {
                _fileUploadSection = value;
                this.ProgressBarSection = !value;
                this.OnPropertyChanged("FileUploadSection");
                if (value)
                {
                    this.PopupHeight = 402;
                }

            }
        }

        public bool ProgressBarSection
        {
            get { return _progressBarSection; }
            set
            {
                _progressBarSection = value;
                OnPropertyChanged("ProgressBarSection");
                if (value)
                {
                    this.PopupHeight = 228;
                }
            }
        }

        public double PopupHeight
        {
            get { return _popupHeight; }
            set { _popupHeight = value; this.OnPropertyChanged("PopupHeight"); }
        }

        private void InitialLoad()
        {
            this.InProgress = true;
            this.FileUploadSection = true;
            this.IsCompleted = false;
            this.PopupHeight = 402;
            this.FailedProductList = new List<AddProductDto>();
            this.FilePath = string.Empty;
            this.ClearCounts();
            this.CSVHasError = false;
        }

        public double ProgressBarValue
        {
            get { return _progressBarValue; }
            set { _progressBarValue = value; this.OnPropertyChanged("ProgressBarValue"); }
        }

        public List<AddProductDto> FailedProductList
        {
            get { return _failedProductList; }
            set { _failedProductList = value; this.OnPropertyChanged("FailedProductList"); }
        }

        public int NumberOfNew
        {
            get { return _numberOfNew; }
            set { _numberOfNew = value; this.OnPropertyChanged("NumberOfNew"); }
        }

        public int NumberOfTotal
        {
            get { return _numberOfTotal; }
            set { _numberOfTotal = value; this.OnPropertyChanged("NumberOfTotal"); }
        }

        public int NumberOfUpdated
        {
            get { return _numberOfUpdated; }
            set { _numberOfUpdated = value; this.OnPropertyChanged("NumberOfUpdated"); }
        }

        public int NumberOfFiled
        {
            get { return _numberOfFiled; }
            set { _numberOfFiled = value; this.OnPropertyChanged("NumberOfFiled"); }
        }

        public string ImportCompleteImageUri
        {
            get { return _importCompleteImageUri; }
            set { _importCompleteImageUri = value; this.OnPropertyChanged("ImportCompleteImageUri"); }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                if (value)
                {
                    this.PopupHeight = 470;
                }

                this.OnPropertyChanged("IsCompleted");
            }
        }

        public bool InProgress
        {
            get { return _inProgress; }
            set { _inProgress = value; this.OnPropertyChanged("InProgress"); }
        }

        public string ImportCompleteMessage
        {
            get { return _importCompleteMessage; }
            set { _importCompleteMessage = value; this.OnPropertyChanged("ImportCompleteMessage"); }
        }

        public bool CSVHasError
        {
            get { return _csvHasError; }
            set
            {
                _csvHasError = value;
                this.OnPropertyChanged("CSVHasError");
                this.CSVHasNoError = !value;
            }
        }

        public bool CSVHasNoError
        {
            get { return _csvHasNoError; }
            set { _csvHasNoError = value; this.OnPropertyChanged("CSVHasNoError"); }
        }


        private void BrowseFile()
        {
            var openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "CSV Only|*.csv";
            var result = openFileDlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var success = this._productService.ValidateCSV(openFileDlg.FileName);
                if (success)
                {
                    ///FileNameTextBox.Text = openFileDlg.FileName;
                    this.FilePath = openFileDlg.FileName;
                }
                else
                {
                    this.FilePath = string.Empty;
                    _dialogService.OpenMessageBox("Error", "Invalid CSV file selected", EnumMaster.MessageBoxType.Error);
                }
            }
        }

        private void Cancel(object obj)
        {
            this.InitialLoad();
            var window = (IDialogWindow)obj;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Unidefined.ToString());
        }

        private async void ProceedFileUpload()
        {
            this.FileUploadSection = false;
            var productMainDto = await this._productService.ImportPriceListAsync(this.FilePath);
            var priceList = productMainDto.ProductList;
            bool success = false;
            if (priceList != null && priceList.Any())
            {
                this.FailedProductList = new List<AddProductDto>();
                productMainDto.Username = _userStore.IsAuth.Username;
                var productMain = await this._productService.AddProductMainAsync(productMainDto);
                double i = 0;
                var productList = new List<Products>();
                foreach (var item in priceList)
                {
                    var value = i / (double)priceList.Count * 100;
                    this.ProgressBarValue = value;
                    item.User = _userStore.IsAuth.Username;
                    item.ProductMainId = productMain.Id;
                    var validatedProduct = this._productService.ValidateProductSave(item, true);
                    if (validatedProduct.IsValid)
                    {
                        var product = await this._productService.SetProductModelAsync(item);
                        productList.Add(product);
                    }
                    else
                    {
                        this.FailedProductList.Add(validatedProduct);
                    }

                    i++;
                }

                var productListForDelete = await this._productService.GetProductsBySkuListAync(productList.Select(a => a.Sku).ToList());
                success = await this._productService.AddProductBulkAsync(productList, productListForDelete);
                this.SetSummaryPage(success, priceList.Count, productListForDelete.Count);
            }
        }

        private void SetSummaryPage(bool success, int totalProductCount, int existProductCount)
        {
            if (success)
            {
                this.ClearCounts();
                this.FilePath = string.Empty;
                this.ProgressBarSection = false;
                this.IsCompleted = true;
                this.InProgress = false;

                this.NumberOfTotal = totalProductCount;
                this.NumberOfFiled = this.FailedProductList.Count;
                this.NumberOfUpdated = this.NumberOfTotal - this.NumberOfFiled;
                this.NumberOfNew = this.NumberOfUpdated - existProductCount;
                if (this.FailedProductList.Any())
                {
                    this.ImportCompleteImageUri = "/Resources/Images/error-icon.png";
                    this.ImportCompleteMessage = "Price List Updated With Errors";
                    this.CSVHasError = true;
                    this.PopupHeight = 470;
                }
                else
                {
                    this.ImportCompleteImageUri = "/Resources/Images/check-green.png";
                    this.ImportCompleteMessage = "Price List Updated Successfully";
                    this.CSVHasError = false;
                    this.PopupHeight = 322;
                }
            }
        }

        private async void DownloadCSV()
        {
            var succss = await this._productService.CreateCSVAsync(this.FailedProductList);
            if (succss)
            {
                _dialogService.OpenMessageBox("Success", "File saved successfully", EnumMaster.MessageBoxType.Success);
            }
        }

        private void ClearCounts()
        {
            this.NumberOfTotal = 0;
            this.NumberOfTotal = 0;
            this.NumberOfFiled = 0;
            this.NumberOfUpdated = 0;
            this.NumberOfNew = 0;
            this.ProgressBarValue = 0;
        }
    }
}
