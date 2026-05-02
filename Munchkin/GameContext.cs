using Munchkin.Systems;

namespace Munchkin
{
    /// <summary>
    /// Holds references to all the systems and managers that need to be accessed by effects and phases
    /// </summary>
    public class GameContext
    {
        public CardRegistry CardRegistry { get; set; }
        public DeckBuilder DeckBuilder { get; set; }
        public TurnSystem  TurnSystem { get; set; }
        public Random Random { get; set; }
    }
}
