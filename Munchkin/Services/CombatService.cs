using Munchkin.Cards;   
using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Services;
using Munchkin.Cards.Components;

namespace Munchkin.Services
{
    public class CombatService
    {
        public bool EvaluateCombat(Player player, CardInstance monster)
        {
            int monsterLevel = monster.Definition.GetComponent<MonsterComponent>().Level;
            int playerLevel = player.Level;
            return playerLevel >= monsterLevel;
        }
    }
}

