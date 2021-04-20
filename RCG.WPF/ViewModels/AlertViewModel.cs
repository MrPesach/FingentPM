using RCG.CoreApp.Enums;
using RCG.WPF.Commands;
using RCG.WPF.DialogServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public class AlertViewModel : DialogViewModelBase<EnumMaster.DialogResults>
    {
        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }
        public ICommand OkCommand { get; }
        public AlertViewModel()
        {
            this.YesCommand = new RelayCommand(o => this.Yes(o));
            this.NoCommand = new RelayCommand(o => this.No(o));
            this.OkCommand = new RelayCommand(o => this.Ok(o));
        }

        public string IconUri { get; set; }
        public bool IsConfirmation { get; set; }
        public bool IsAlert { get; set; }

        private void Yes(object obj)
        {
            CloseDialog(obj, EnumMaster.DialogResults.Yes);
        }

        private void No(object obj)
        {
            CloseDialog(obj, EnumMaster.DialogResults.No);
        }

        private void Ok(object obj)
        {
            CloseDialog(obj, EnumMaster.DialogResults.OK);
        }

        private void CloseDialog(object obj, EnumMaster.DialogResults dialogResult)
        {
            var window = (IDialogWindow)obj;
            CloseDialogWithResult(window, dialogResult);
        }
    }
}
