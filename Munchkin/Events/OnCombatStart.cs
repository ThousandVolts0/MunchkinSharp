using Munchkin.Cards;
using Munchkin.Events;

namespace Munchkin.Phases
{
    public class OnCombatStart : IGameEvent
    {
        public required Player Player { get; set; }
        public required CardInstance Monster { get; set; }
        public required int Bonus { get; set; }
    }
}