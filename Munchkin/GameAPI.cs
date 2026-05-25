using Munchkin.Registries;
using Munchkin.Services;
using System.Windows.Input;
using Munchkin.Cards;
using Munchkin.Events;

namespace Munchkin
{
    public class GameAPI
    {
        private GameServices _services;
        internal GameAPI(GameServices services)
        {
            _services = services;
        }

        public IReadOnlyList<Player> Players => _services.Get<TurnService>().Players;
        public Player CurrentPlayer => _services.Get<TurnService>().CurrentPlayer;

        public void DrawCard(Player player, CardType type)
        {
            CardInstance card = _services.Get<DeckService>().Draw(type);
            _services.Get<CardInteractionService>().AddToHand(card, player);
        }

        public void PlayCard(Player player, CardInstance card)
        {
            _services.Get<CardInteractionService>().Play(card, player);
        }
    }
}
