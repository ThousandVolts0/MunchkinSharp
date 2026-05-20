using Munchkin.Cards;

namespace Munchkin.Events
{
    public class OnCardPlayed : IGameEvent
    {
        public CardInstance Card { get; set; }
        public Player Player { get; set; }

        public OnCardPlayed(Player player, CardInstance card)
        {
            Player = player;
            Card = card;
        }
    }
}
