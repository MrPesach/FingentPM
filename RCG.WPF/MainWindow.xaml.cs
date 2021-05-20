using System.Windows;

namespace RCG.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();
            ////MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            ////MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.Width = 1272;
            this.Height = 592;
            this.DataContext = dataContext;
        }

        private void MasterWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
