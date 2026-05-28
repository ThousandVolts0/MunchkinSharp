using Munchkin.Cards;
using Munchkin.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Registries
{
    public class GameRegistry
    {
        public IRegistry<CardDefinition> Cards { get; } = new CardRegistry();
        public IRegistry<EffectDefinition> Effects { get; } = new EffectRegistry();
    }
}
