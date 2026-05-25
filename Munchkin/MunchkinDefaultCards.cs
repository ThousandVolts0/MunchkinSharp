using Munchkin.Registries;
using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Cards;
using Munchkin.Effects;
using Munchkin.Events;

namespace Munchkin
{
    internal static class MunchkinDefaultCards
    {
        internal static void Load(GameRegistry registry)
        {
            registry.Cards.Register("monster_1", new CardDefinition
            {
                Name = "Monster 1",
                Effects = new()
                {
                    EffectFactory.Create<OnCombatWin>(
                        (e, api, card) => e.Player.Level += card.Definition.Data.Get<int>("LevelsGained"),
                        (e, api, card) => e.Monster == card), // Only trigger if self
                    EffectFactory.Create<OnCombatLose>(
                        (e, api, card) => e.Player.Level -= card.Definition.Data.Get<int>("LevelsLost"),
                        (e, api, card) => e.Monster == card), // Only trigger if self
                },
                Type = CardType.Door,
                Tags = { CardTag.Monster },
                Data = 
                { 
                    ["Level"] = 5, 
                    ["Treasures"] = 3,
                    ["LevelsGained"] = 1,
                    ["LevelsLost"] = 1
                }
            });
        }
    }
}
