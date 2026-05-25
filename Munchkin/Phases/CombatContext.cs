using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Phases
{
    public class CombatContext : IPhaseContext
    {
        public Player ActivePlayer { get; }
        public CardInstance Monster { get; }
        public CombatContext(Player activePlayer, CardInstance monster)
        {
            ActivePlayer = activePlayer;
            Monster = monster;
        }
    }
}
