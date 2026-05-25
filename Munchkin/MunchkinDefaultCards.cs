using Munchkin.Registries;
using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Cards;
using Munchkin.Effects;
using Munchkin.Events;
using Munchkin.Cards.Components;
using Munchkin.Phases;

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
                    .Build(),

                    new EffectBuilder<OnCombatStart>()
                    .Execute((e, api, card) => e.Bonus += 5)
                    .When((e,api,source) => e.Monster == source)
                    .WithPriority(0)
                    .Build(),

                    new EffectBuilder<OnCardSerialize>()
                    .Execute((e,api,card) => Console.WriteLine("This is a testing card"))
                    .When((e,api,source) => e.Card == source)
                    .WithPriority(0)
                    .Build(),
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
