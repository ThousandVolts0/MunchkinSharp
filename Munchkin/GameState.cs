using Munchkin.Phases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class GameState
    {
        public IGamePhase CurrentPhase { get; set; }
        public bool IsRunning { get; set; } = false;
        public List<Player> Players { get; } = new();
    }
}
