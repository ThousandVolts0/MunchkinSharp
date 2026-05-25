using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Events
{
    public class OnCardSerialize : IGameEvent
    {
        public required CardInstance Card;
    }
}
