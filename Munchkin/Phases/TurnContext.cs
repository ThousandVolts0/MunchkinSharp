using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Phases
{
    public class TurnContext : IPhaseContext
    {
        public Player ActivePlayer { get; }

        public TurnContext(Player activePlayer)
        {
            ActivePlayer = activePlayer;
        }
    }
}
