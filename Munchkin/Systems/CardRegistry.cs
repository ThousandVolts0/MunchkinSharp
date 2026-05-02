using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Systems
{
    public class CardRegistry
    {
        private Dictionary<string, Card> _cards = new Dictionary<string, Card>();

        public void Register(string identifier, Card card)
        {
            if (_cards.ContainsKey(identifier))
            {
                throw new InvalidOperationException($"A card with the identifier '{identifier}' is already registered.");
            }
            _cards[identifier] = card;
        }

        public void Unregister(string identifier)
        {
            if (!_cards.ContainsKey(identifier))
            {
                throw new InvalidOperationException($"No card with the identifier '{identifier}' is registered.");
            }
            _cards.Remove(identifier);
        }

        public Card Get(string identifier)
        {
            if (!_cards.ContainsKey(identifier))
            {
                throw new InvalidOperationException($"No card with the identifier '{identifier}' is registered.");
            }
            return _cards[identifier];
        }

        public IReadOnlyList<Card> GetAll()
        {
            return new List<Card>(_cards.Values).AsReadOnly();
        }
    }
}
