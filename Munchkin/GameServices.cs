using Munchkin.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class GameServices
    {
        public TurnService TurnSystem { get; set; }
        public CardService CardSystem { get; set; }
        public EffectDispatcher EffectDispatcher { get; set; }

        public Deck TreasureDeck { get; set; }
        public Deck DoorDeck { get; set; }
    }
}
