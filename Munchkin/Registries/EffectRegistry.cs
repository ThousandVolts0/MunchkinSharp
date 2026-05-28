using Munchkin.Cards;
using Munchkin.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Registries
{
    public class EffectRegistry : IRegistry<EffectDefinition>
    {
        private Dictionary<string, EffectDefinition> _effects = new Dictionary<string, EffectDefinition>();

        public void Register(string identifier, EffectDefinition effect)
        {
            if (_effects.ContainsKey(identifier))
            {
                throw new InvalidOperationException($"An effect with the identifier '{identifier}' is already registered.");
            }
            _effects[identifier] = effect;
        }

        public void Unregister(string identifier)
        {
            if (!_effects.ContainsKey(identifier))
            {
                throw new InvalidOperationException($"No effect with the identifier '{identifier}' is registered.");
            }
            _effects.Remove(identifier);
        }

        /// <summary>
        /// Getter-only indexer for easy lookup of cards and obvious fail case
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>The card found or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public EffectDefinition this[string identifier] => _effects.ContainsKey(identifier) 
            ? _effects[identifier] 
            : throw new ArgumentException($"No effect with identifier \"{identifier}\" was found");

        public IReadOnlyList<EffectDefinition> GetAll()
        {
            return new List<EffectDefinition>(_effects.Values).AsReadOnly();
        }
    }
}
