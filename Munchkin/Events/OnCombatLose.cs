using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Cards;

namespace Munchkin.Events
{
    internal class OnCombatLose : IGameEvent
    {
        public required Player Player { get; set; }
        public required CardInstance Monster { get; set; }
    }
}
