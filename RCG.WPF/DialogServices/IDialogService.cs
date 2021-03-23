using RCG.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.WPF.Services
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}
