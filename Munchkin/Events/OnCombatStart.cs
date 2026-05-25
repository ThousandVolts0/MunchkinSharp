using Munchkin.Cards;
using Munchkin.Events;

namespace Munchkin.Phases
{
    internal class OnCombatStart : IGameEvent
    {
        public required Player Player { get; set; }
        public required CardInstance Monster { get; set; }
    }
}