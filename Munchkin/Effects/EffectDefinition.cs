using Munchkin.Cards;
using Munchkin.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Effects
{
    public class EffectDefinition
    {
        internal EffectDefinition() { }
        public Type EventType { get; set; }
        public Action<IGameEvent, GameAPI, CardInstance> Action { get; set; }
        public Func<IGameEvent, GameAPI, CardInstance, bool>? Condition { get; set; }
        public int Priority { get; set; } = 0; // Lower priority effects are executed first

        public EffectInstance CreateInstance(CardInstance source)
        {
            return new EffectInstance(this, source);
        }
    }
}
