using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels.EventArgs
{
    public class AddCombatantEventArgs
    {
        public Combatant Combatant { get; set; }
        public bool Add { get; set; }
    }
}
