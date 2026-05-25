using Munchkin.Registries;
using Munchkin.Services;
using System.Windows.Input;
using Munchkin.Cards;
using Munchkin.Events;
using Munchkin.Phases;

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

        public bool HasCard(Player player, CardInstance card, bool inHand = false)
        {
            CardInteractionService cardService = _services.Get<CardInteractionService>();
            return inHand ? cardService.HasCardInHand(player, card) : cardService.HasCardInPlay(player, card);
        }

        public bool HasCard(Player player, CardInstance card, bool inHand = false, Func<CardInstance, bool>? condition = null)
        {
            CardInteractionService cardService = _services.Get<CardInteractionService>();
            return inHand ? cardService.HasCardInHand(player, card, condition) : cardService.HasCardInPlay(player, card, condition);
        }

        public void DrawCard(Player player, CardType type)
        {
            CardInstance card = _services.Get<DeckService>().Draw(type);
            _services.Get<CardInteractionService>().AddCardToHand(card, player);
        }

        public void AddCard(Player player, CardInstance card) => _services.Get<CardInteractionService>().AddCardToHand(card, player);

        public void RemoveCard(Player player, CardInstance card) => _services.Get<CardInteractionService>().RemoveCardFromHand(card, player);

        public void PlayCard(Player player, CardInstance card) => _services.Get<CardInteractionService>().PlayCard(card, player);

        public void DiscardCard(Player player, CardInstance card) => _services.Get<CardInteractionService>().DiscardCard(card, player);
    }
}
