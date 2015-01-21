using System.Windows;
using System.Windows.Controls;

namespace InitiativeTracker.MVVM.Views
{
    /// <summary>
    /// Interaction logic for EndCombatView.xaml
    /// </summary>
    public partial class EndCombatView : UserControl
    {
        public EndCombatView()
        {
            InitializeComponent();
        }

        //HACK Maybe... ?
        private void Close(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null) window.Close();
        }
    }
}
