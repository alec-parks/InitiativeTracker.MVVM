using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Assisticant;
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
            ViewModel.AddCombatantEvent     += AddCombatantEventHandler;
            ViewModel.SetInitiativeEvent    += StartCombatEventHandler;
            ViewModel.EndCombatEvent        += EndCombatEventHandler; 
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCombatantEvent     -= AddCombatantEventHandler;
            ViewModel.SetInitiativeEvent    -= StartCombatEventHandler;
            ViewModel.EndCombatEvent        -= EndCombatEventHandler;
        }

        private void AddCombatantEventHandler(object sender, AddCombatantEventArgs e)
        {
            var addCombatantDiag = new AddCombatantDialog {ShowInTaskbar = false, Owner = Window.GetWindow(this)};
            if (addCombatantDiag.ShowDialog() == true)
            {
                e.Confirmed = true;
                e.Combatant = addCombatantDiag.Combatant;
            }
        }

        private void StartCombatEventHandler(object sender, SetInitiativeEventArgs e)
        {
            var dispatcher = Dispatcher.CurrentDispatcher;

            dispatcher.BeginInvoke((Action)(() =>
            {
                var setInitiativeDiag = new SetInitiativeDialog
                {
                    ShowInTaskbar = false,
                    Owner = Window.GetWindow(this),
                };
                setInitiativeDiag.ShowDialog();
            }));
        }

        private void EndCombatEventHandler(object sender, EndCombatEventArgs e)
        { }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.RemoveCombatant.RaiseCanExecuteChanged();
            ViewModel.AddCopy.RaiseCanExecuteChanged();
        }
    }
}
