using System.Windows;
using System.Windows.Controls;
using InitiativeTracker.MVVM.ViewModels;
using InitiativeTracker.MVVM.ViewModels.EventArgs;

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
            get { return (CombatViewModel)DataContext; }
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
            var a = 1;
            a++;
        }


    }
}
