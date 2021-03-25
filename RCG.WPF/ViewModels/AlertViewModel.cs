using RCG.CoreApp.Enums;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class AlertViewModel : DialogViewModelBase<string>
    {
        public ICommand CancelCommand { get; }
        public AlertViewModel()
        {
            this.CancelCommand = new RelayCommand(o => this.CloseDialog(o), o => true);
        }

        public string IconUri { get; set; }

        private void CloseDialog(object obj)
        {
            var window = (IDialogWindow)obj;
            CloseDialogWithResult(window, EnumMaster.DialogResults.Yes.ToString());
        }
    }
}
