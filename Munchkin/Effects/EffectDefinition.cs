using Munchkin.Cards;
using Munchkin.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Effects
{
    public class EffectDefinition
    {
        public required Type EventType { get; set; }
        public required Action<IGameEvent, GameAPI, CardInstance> Action { get; set; }
        public Func<IGameEvent, GameAPI, CardInstance, bool>? Condition { get; set; }

        public EffectInstance CreateInstance(CardInstance source)
        {
            return new EffectInstance(this, source);
        }
    }
}
