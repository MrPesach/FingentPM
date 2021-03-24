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
            window.Owner = parentWindow;
            window.DataContext = viewModel;
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
