using RCG.WPF.State.Navigators;

namespace RCG.WPF.ViewModels.Factories
{
    public interface IProductManagerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
