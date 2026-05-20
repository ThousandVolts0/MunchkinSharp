using Munchkin.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Cards
{
    public class CardInstance
    {
        public CardDefinition Definition { get; set; }
        public List<EffectInstance> Effects { get; } = new();

        public CardInstance(CardDefinition definition)
        {
            Definition = definition;

            // Make effect definitions into instances
            foreach (EffectDefinition effectDef in Definition.Effects)
            {
                Effects.Add(effectDef.CreateInstance(this));
            }
        }
    }
}
