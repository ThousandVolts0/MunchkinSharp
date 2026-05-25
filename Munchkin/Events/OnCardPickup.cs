using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Cards;

namespace Munchkin.Events
{
    public class OnCardPickup : IGameEvent
    {
        public required Player Player { get; set; }
        public required CardInstance Card { get; set; }
    }
}
