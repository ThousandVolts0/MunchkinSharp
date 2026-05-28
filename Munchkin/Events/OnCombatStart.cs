using Munchkin.Cards;
using Munchkin.Events;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.Json;

namespace Munchkin.Phases
{
    public class OnCombatStart : IGameEvent
    {
        public Player Player { get; set; }
        public CardInstance Monster { get; set; }

        public TrackedValue<int> Bonus { get; } = new();

        public OnCombatStart(Player player, CardInstance monster)
        {
            Player = player;
            Monster = monster;
        }
    }
}