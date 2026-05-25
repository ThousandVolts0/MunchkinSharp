using Munchkin.Registries;
using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Cards;
using Munchkin.Effects;
using Munchkin.Events;
using Munchkin.Cards.Components;

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
                    new EffectBuilder<OnCombatLose>()
                    .Execute((e, api, card) => Console.WriteLine("Test"))
                    .When((e,api,source) => e.Monster == source)
                    .WithPriority(0)
                    .Build()
                },
                Type = CardType.Door,
                Components =
                {
                    new MonsterComponent
                    {
                        Level = 1,
                        TreasureCount = 1,
                        LevelsGained = 1,
                        LevelsLost = 1,
                    }
                }
            });
        }
    }
}
