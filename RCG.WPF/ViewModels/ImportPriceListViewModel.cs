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
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class ImportPriceListViewModel : DialogViewModelBase<string>
    {
        public ICommand BrowseFileCommand { get; }
        public ICommand ProceedCommand { get; }
        public ICommand CancelCommand { get; }
        private readonly IProductService _productService;
        private readonly IUserStore _userStore;

        public ImportPriceListViewModel(IProductService productService, IUserStore userStore)
        {
            _productService = productService;
            _userStore = userStore;
            this.ProceedCommand = new RelayCommand(o => this.ProceedFileUpload(), o => this.CanExecute);
            this.BrowseFileCommand = new RelayCommand(o => this.BrowseFile(), o => true);
            this.CancelCommand = new RelayCommand(o => this.Cancel(o), o => true);
            this.InitialLoad();
        }

        private bool _fileUploadSection;
        private bool _progressBarSection;
        private double _popupHeight;
        private double _progressBarValue;
        private int _numberOfFailed;
        private int _numberOfNew;
        private int _numberOfTotal;

        public bool CanExecute => !string.IsNullOrEmpty(this.FilePath) && !ProgressBarSection;

        public string FilePath { get; set; }

        public bool FileUploadSection
        {
            get { return _fileUploadSection; }
            set
            {
                _fileUploadSection = value;
                this.ProgressBarSection = !value;
                this.PopupHeight = value ? 402 : 228;
                OnPropertyChanged("FileUploadSection");
            }
        }

        public bool ProgressBarSection
        {
            get { return _progressBarSection; }
            set { _progressBarSection = value; OnPropertyChanged("ProgressBarSection"); }
        }

        public double PopupHeight
        {
            get { return _popupHeight; }
            set { _popupHeight = value; this.OnPropertyChanged("PopupHeight"); }
        }

        private void InitialLoad()
        {
            this.FileUploadSection = true;
            this.PopupHeight = 402;
        }

        public double ProgressBarValue
        {
            get { return _progressBarValue; }
            set { _progressBarValue = value; this.OnPropertyChanged("ProgressBarValue"); }
        }

        public int NumberOfFailed
        {
            get { return _numberOfFailed; }
            set { _numberOfFailed = value; this.OnPropertyChanged("NumberOfFailed"); }
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

        private void BrowseFile()
        {
            var openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "CSV Only|*.csv";
            var result = openFileDlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                ///FileNameTextBox.Text = openFileDlg.FileName;
                this.FilePath = openFileDlg.FileName;
            }
        }

        private void Cancel(object obj)
        {
            var window = (IDialogWindow)obj;
            this.FileUploadSection = true;
            this.FilePath = string.Empty;
            this.NumberOfFailed = 0;
            this.ProgressBarValue = 0;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Unidefined.ToString());
        }

        private async Task<bool> ProceedFileUpload()
        {
            this.FileUploadSection = false;
            var productMainDto = await this._productService.ImportPriceListAsync(this.FilePath);
            var priceList = productMainDto.PriceList;
            bool success = false;
            if (priceList != null && priceList.Any())
            {
                productMainDto.Username = _userStore.IsAuth.Username;
                var productMain = await this._productService.AddProductMainAsync(productMainDto);
                productMainDto.ProductMainId = productMain.Id;

                double i = 0;
                var productList = new List<Products>();
                foreach (var item in priceList)
                {
                    var value = i / (double)priceList.Count * 100;
                    this.ProgressBarValue = value;
                    var product = await this._productService.SetProductModelAsync(item, productMainDto);
                    if (product != null)
                    {
                        productList.Add(product);
                    }
                    else
                    {
                        this.NumberOfFailed++;
                    }

                    i++;
                }

                success = await this._productService.AddProductAsync(productList);
            }

            return success;
        }
    }
}
