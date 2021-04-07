using RCG.WPF.Commands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace RCG.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand CloseAppCommand { get; }
        public ICommand MaximizeAppCommand { get; }
        public ICommand MinimizeAppCommand { get; }

        public ViewModelBase()
        {
            this.CloseAppCommand = new RelayCommand(a => this.CloseApp());
            this.MaximizeAppCommand = new RelayCommand(a => this.MaximizeApp(a));
            this.MinimizeAppCommand = new RelayCommand(a => this.MinimizeApp(a));
        }

        private void MinimizeApp(object window)
        {
            if (window != null)
            {
                var mainWindow = (Window)window;
                mainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void MaximizeApp(object window)
        {
            if (window != null)
            {
                var mainWindow = (Window)window;
                mainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void CloseApp()
        {
            Application.Current.Shutdown();
        }
        public virtual void Dispose() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler RaPropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = RaPropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
