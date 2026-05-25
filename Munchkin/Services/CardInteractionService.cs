using Munchkin.Cards;
using Munchkin.Events;

namespace Munchkin.Services
{
    public class CardInteractionService
    {
        private readonly EffectDispatchService _dispatcher;

        public CardInteractionService(EffectDispatchService dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void AddCardToHand(CardInstance card, Player player)
        {
            _dispatcher.Subscribe(card.Effects);
            player.Hand.Add(card);
        }

        public void RemoveCardFromHand(CardInstance card, Player player)
        {
            if (player.Hand.Contains(card))
            {
                _dispatcher.Unsubscribe(card.Effects);
                player.Hand.Remove(card);
            }
        }

        public bool HasCardInPlay(Player player, CardInstance card, Func<CardInstance, bool>? condition = null)
        {
            if (condition != null)
                return player.Played.Contains(card) && condition(card);

            return player.Played.Contains(card);
        }

        public bool HasCardInHand(Player player, CardInstance card, Func<CardInstance, bool>? condition = null)
        {
            if (condition != null)
                return player.Hand.Contains(card) && condition(card);

            return player.Hand.Contains(card);
        }

        public void PlayCard(CardInstance card, Player player)
        {
            if (player.Hand.Contains(card))
            {
                _dispatcher.Invoke(new OnCardPlayed(player, card));
                player.Played.Add(card);
                player.Hand.Remove(card);
            }   
        }

        public void DiscardCard(CardInstance card, Player player)
        {
            if (player.Played.Contains(card))
            {
                _dispatcher.Invoke(new OnCardDiscarded { Card = card, Player = player });
                player.Hand.Remove(card);
            }
        }
    }
}
