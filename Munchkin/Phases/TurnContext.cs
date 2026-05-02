using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Phases
{
    public class TurnContext : IPhaseContext
    {
        public required Player ActivePlayer { get; set; }
        public required GameContext GameContext { get; set; }
    }
}
