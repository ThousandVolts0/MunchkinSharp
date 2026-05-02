using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class Deck
    {
        private readonly List<Card> _cards = new();
        public CardType CardType { get; set; }

        public Deck(CardType type)
        {
            CardType = type;
        }

        public void Add(IEnumerable<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public Card Draw()
        {
            var card = _cards.First();
            _cards.Remove(card);
            return card;
        }
    }

    public interface ICard
    {
        public void Add(IEnumerable<Card> cards);
        public Card Draw();
    }
}
