using Munchkin.Registries;
using Munchkin.Systems;
using System.Windows.Input;
using Munchkin.Cards;
using Munchkin.Events;

namespace Munchkin
{
    public class GameAPI
    {
        private GameServices _systems;
        internal GameAPI(GameServices context)
        {
            _systems = context;
        }

        public IReadOnlyList<Player> Players => _systems.TurnSystem.Players;
        public Player CurrentPlayer => _systems.TurnSystem.CurrentPlayer;

        public void DrawCard(Player player, CardType type)
        {
            Deck deck = type switch
            {
                CardType.Door => _systems.DoorDeck,
                CardType.Treasure => _systems.TreasureDeck,
                _ => throw new ArgumentException("Invalid card type")
            };
            _systems.CardSystem.Draw(player, deck);
        }

        public void PlayCard(Player player, CardInstance card)
        {
            _systems.CardSystem.Play(card, player);
        }
    }
}
