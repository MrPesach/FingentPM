using RCG.CoreApp.Enums;
using RCG.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.WPF.Services
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
        EnumMaster.DialogResults OpenMessageBox(string title, string message, EnumMaster.MessageBoxType messageBoxType);
    }
}
