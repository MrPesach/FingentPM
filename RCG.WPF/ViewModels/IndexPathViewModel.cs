using Microsoft.Win32;
using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.Product;
using RCG.CoreApp.Interfaces.Settings;
using RCG.CoreApp.Interfaces.Shared;
using RCG.Domain.Entities;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using RCG.WPF.Services;
using RCG.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class IndexPathViewModel : DialogViewModelBase<EnumMaster.DialogResults>
    {

        private readonly ISettingsService _settingsService;
        private readonly IDialogService _dialogService;
        private readonly IUserStore _userStore;
        private readonly IDateTimeService _dateTimeService;
        private readonly IProductService _productService;

        public ICommand CancelCommand { get; }
        public ICommand SelectPathCommand { get; }
        public ICommand LoadedCommand { get; }
        public ICommand SaveIndexFilePathCommand { get; }

        public IndexPathViewModel(ISettingsService settingsService,
            IDialogService dialogService,
            IUserStore userStore,
            IDateTimeService dateTimeService,
            IProductService productService)
        {
            this.CancelCommand = new RelayCommand(o => this.CloseDialog(o));
            this.SelectPathCommand = new RelayCommand(o => this.SelectPath());
            this.LoadedCommand = new AsyncCommand(o => this.InitialLoadAsync());
            this.SaveIndexFilePathCommand = new AsyncCommand(o => this.SaveIndexFilePathAsync(o));
            this._settingsService = settingsService;
            this._dialogService = dialogService;
            this._userStore = userStore;
            this._dateTimeService = dateTimeService;
            this._productService = productService;
        }

        private string _selectedPath;

        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; this.OnPropertyChanged("SelectedPath"); }
        }

        private void SelectPath()
        {
            using var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                this.SelectedPath = dialog.SelectedPath;
            }
        }

        private void CloseDialog(object windowObject)
        {
            var window = (IDialogWindow)windowObject;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Cancelled);
        }

        private async Task InitialLoadAsync()
        {
            this.SelectedPath = await _settingsService.GetApplConfigValueAsync(EnumMaster.ApplConfig.IndesignIndexFileSavePath);
        }

        private async Task SaveIndexFilePathAsync(object window)
        {
            var displayName = EnumMaster.GetDisplayValue(EnumMaster.ApplConfig.IndesignIndexFileSavePath);
            var applConfig = new ApplConfigs
            {
                CreatedBy = _userStore.IsAuth.Username,
                CreatedOn = _dateTimeService.NowUtc,
                DisplayName = displayName,
                Name = EnumMaster.ApplConfig.IndesignIndexFileSavePath.ToString(),
                ShowtoUser = true,
                Value = this.SelectedPath,
            };

            var success = await this._settingsService.SaveApplConfigValueAsync(applConfig);
            if (success)
            {
                this.CloseDialog(window);
                this._dialogService.OpenMessageBox("Index file download path changed successfully", EnumMaster.MessageBoxType.Success);
                await this._productService.GenerateProductJsonFileAsync();
            }
        }
    }
}
