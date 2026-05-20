using Munchkin.Cards;
using Munchkin.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Registries
{
    public class CardRegistry : IRegistry<CardDefinition>
    {
        private Dictionary<string, CardDefinition> _cards = new Dictionary<string, CardDefinition>();

        public void Register(string identifier, CardDefinition card)
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

        /// <summary>
        /// Getter-only indexer for easy lookup of cards and obvious fail case
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>The card found or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public CardDefinition this[string identifier] => _cards.ContainsKey(identifier) 
            ? _cards[identifier] 
            : throw new ArgumentException($"No card with identifier \"{identifier}\" was found");

        public IReadOnlyList<CardDefinition> GetAll()
        {
            return new List<CardDefinition>(_cards.Values).AsReadOnly();
        }
    }
}
