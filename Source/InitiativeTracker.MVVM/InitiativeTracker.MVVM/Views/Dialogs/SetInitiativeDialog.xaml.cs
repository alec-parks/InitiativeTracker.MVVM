using System.Windows;

namespace InitiativeTracker.MVVM.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for SetInitiativeDialog.xaml
    /// </summary>
    public partial class SetInitiativeDialog : Window
    {
        public SetInitiativeDialog()
        {
            InitializeComponent();
        }

        private void Start_Combat_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
