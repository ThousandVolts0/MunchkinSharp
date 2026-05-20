using Munchkin.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Effects
{
    public class EffectInstance
    {
        public EffectDefinition Definition { get; set; }
        public CardInstance Source { get; set; }

        public EffectInstance(EffectDefinition definition, CardInstance source)
        {
            Definition = definition;
            Source = source;
        }
    }
}
