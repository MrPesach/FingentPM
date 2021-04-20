using System.Windows.Controls;

namespace RCG.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        private void MainButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Get the button and check for nulls
            Button button = sender as Button;
            if (button == null || button.ContextMenu == null)
                return;
            // Set the placement target of the ContextMenu to the button
            button.ContextMenu.PlacementTarget = button;
            // Open the ContextMenu
            button.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Left;
            button.ContextMenu.HorizontalOffset = button.ActualWidth + 7;
            button.ContextMenu.VerticalOffset = button.ActualHeight + 2;
            button.ContextMenu.IsOpen = true;
            e.Handled = true;
        }
    }
}
