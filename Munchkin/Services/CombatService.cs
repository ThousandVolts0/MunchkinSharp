using Munchkin.Cards;   
using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Services;

namespace Munchkin.Services
{
    public class CombatService
    {
        public bool EvaluateCombat(Player player, CardInstance monster)
        {
            int monsterLevel = monster.Definition.Data.Get<int>("Level");
            int playerLevel = player.Level;
            return playerLevel >= monsterLevel;
        }

        public bool ShouldStartCombat(CardInstance card)
        {
            return card.Definition.Tags.Contains(CardTag.Monster) && card.Definition.Data.ContainsKey("Level");
        }
    }
}

