using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RCG.WPF.DialogServices
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        public Window Owner { get; set; }
        bool? ShowDialog();
        double MaxHeight { get; set; }
        double MaxWidth { get; set; }
    }
}
