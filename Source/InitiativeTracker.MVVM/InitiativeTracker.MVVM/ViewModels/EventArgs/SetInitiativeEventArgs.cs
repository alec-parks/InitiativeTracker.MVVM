using System.Collections.Generic;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels.EventArgs
{
    public class SetInitiativeEventArgs
    {
        public IEnumerable<Combatant> Combatants { get; set; }
        public bool Confirmed { get; set; }
    }
}
