using System.Windows;
using System.Windows.Controls;
using Assisticant;
using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.ViewModels;
using InitiativeTracker.MVVM.ViewModels.EventArgs;
using InitiativeTracker.MVVM.Views.Dialogs;

namespace InitiativeTracker.MVVM.Views
{
    /// <summary>
    /// Interaction logic for CombatView.xaml
    /// </summary>
    public partial class CombatView : UserControl
    {
        public CombatView()
        {
            InitializeComponent();
        }

        private CombatViewModel ViewModel
        {
            get { return ForView.Unwrap<CombatViewModel>(DataContext); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCombatantEvent += AddCombatantEventHandler;
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCombatantEvent -= AddCombatantEventHandler;
        }

        private void AddCombatantEventHandler(object sender, AddCombatantEventArgs e)
        {
            e.Confirmed = true;
            e.Combatant = new Combatant
            {
                Name = "Test Combatant",
                Type = CombatantType.Monster,
                Counter = 1,
                Initiative = new Initiative { Modifier = -5, Current = 13, IsSet = true }
            };
        }


    }
}
