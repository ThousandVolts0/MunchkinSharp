using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Cards.Components
{
    public class TreasureComponent : ICardComponent
    {
        public required int GoldValue { get; set; }
    }
}
