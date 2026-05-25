using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Events
{
    internal class OnCombatWin : IGameEvent
    {
        public required Player Player { get; set; }
        public required CardInstance Monster { get; set; }
    }
}
