using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin
{
    public class Deck
    {
        private readonly List<CardInstance> _cards;

        public Deck(List<CardInstance> cards)
        {
            _cards = cards;
        }

        public void Shuffle(Random rand)
        {
            int count = _cards.Count;
            List<CardInstance> copy = new(_cards);
            _cards.Clear();

            for (int i = 0; i < count; i++)
            {
                CardInstance card = copy[rand.Next(copy.Count)];
                _cards.Add(card);
                copy.Remove(card);
            }
        }

        public CardInstance Draw()
        {
            var card = _cards.LastOrDefault();
            if (card == null)
                throw new InvalidOperationException("Deck is empty");
            _cards.Remove(card);
            return card;
        }
    }
}
