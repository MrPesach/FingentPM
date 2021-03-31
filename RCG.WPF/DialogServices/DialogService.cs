using RCG.CoreApp.Enums;
using RCG.WPF.DialogServices;
using RCG.WPF.ViewModels;
using RCG.WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RCG.WPF.Services
{
    public class DialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            var parentWindow = Application.Current.MainWindow;
            IDialogWindow window = new DialogWindow();
            window.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            window.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            window.Owner = parentWindow;
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }

        public EnumMaster.DialogResults OpenMessageBox(string title, string message, EnumMaster.MessageBoxType messageBoxType)
        {
            var viewModel = new AlertViewModel
            {
                Message = message,
                Title = title,
            };

            viewModel.IconUri = messageBoxType == EnumMaster.MessageBoxType.Success ? "/Resources/Images/check-green.png" : "/Resources/Images/error-icon.png";
            viewModel.IsConfirmation = messageBoxType == EnumMaster.MessageBoxType.Confirmation;
            viewModel.IsAlert = messageBoxType != EnumMaster.MessageBoxType.Confirmation;


            var parentWindow = Application.Current.MainWindow;
            IDialogWindow window = new DialogWindow();
            window.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            window.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            window.Owner = parentWindow;
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
