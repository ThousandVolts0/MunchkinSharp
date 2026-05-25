using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Services
{
    internal class DeckService
    {
        private readonly Dictionary<CardType, Deck> _decks = new();

        public void Create(CardType type) => _decks[type] = new Deck();

        public void Fill(CardType type, List<CardDefinition> cards, int each, int max) => _decks[type].Fill(cards, each, max);

        public CardInstance Draw(CardType type) => _decks[type].Draw();

        public void Clear(CardType type) => _decks[type].Clear();

        public void Shuffle(CardType type, Random rand) => _decks[type].Shuffle(rand);
    }
}
