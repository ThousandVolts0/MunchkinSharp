using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Events
{
    public class OnCardDiscarded : IGameEvent
    {
        public required Player Player { get; set; }
        public required CardInstance Card { get; set; }
    }
}
