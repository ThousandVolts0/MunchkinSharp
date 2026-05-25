using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Cards.Components
{
    public class MonsterComponent : ICardComponent
    {
        public required int Level { get; set; }
        public required int TreasureCount { get; set; }
        public required int LevelsLost { get; set; }
        public required int LevelsGained { get; set; }
    }
}
