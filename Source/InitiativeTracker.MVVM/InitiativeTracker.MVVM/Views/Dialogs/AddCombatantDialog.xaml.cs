using System.Windows;
using InitiativeTracker.MVVM.ViewModels;

namespace InitiativeTracker.MVVM.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCombatantDialog.xaml
    /// </summary>
    public partial class AddCombatantDialog : Window
    {
        public AddCombatantDialog()
        {
            InitializeComponent();
        }

        public AddCombatantViewModel AddCombatantViewModel { get;set;}

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
