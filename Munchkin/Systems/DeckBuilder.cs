using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Systems
{
    public class DeckBuilder
    {
        private readonly CardRegistry _cardRegistry;

        public DeckBuilder(CardRegistry cardRegistry)
        {
            _cardRegistry = cardRegistry;
        }

        public Deck CreateDeck(CardType type)
        {
            return new Deck(type);
        }

        public Deck FillDeck(Deck deck, int max)
        {
            deck.Add(_cardRegistry.GetAll()
                .Where(x => x.CardType == deck.CardType)
                .Take(max));

            return deck;
        }
    }
}
