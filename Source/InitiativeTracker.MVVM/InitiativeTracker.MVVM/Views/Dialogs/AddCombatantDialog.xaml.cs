using System.Windows;
using Assisticant;
using InitiativeTracker.MVVM.Models;
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

        private AddCombatantViewModel ViewModel
        {
            get { return ForView.Unwrap<AddCombatantViewModel>(DataContext); }

        }

        public Combatant Combatant
        {
            get { return ViewModel.Combatant; }
        }

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
