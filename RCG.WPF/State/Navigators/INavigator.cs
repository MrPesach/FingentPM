using System;
using RCG.WPF.ViewModels;

namespace RCG.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Products,
        UserSetup
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
