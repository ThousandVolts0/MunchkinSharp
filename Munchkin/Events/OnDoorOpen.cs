using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Events
{
    internal class OnDoorOpen : IGameEvent
    {
        public required CardInstance Card { get; set; }
        public required Player Player { get; set; }
    }
}
