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

        public void AddToHand(CardInstance card, Player player)
        {
            _dispatcher.Subscribe(card.Effects);
            player.Hand.Add(card);
        }

        public void Play(CardInstance card, Player player)
        {
            if (player.Hand.Contains(card))
            {
                _dispatcher.Invoke(new OnCardPlayed(player, card));
                player.Played.Add(card);
                player.Hand.Remove(card);
            }   
        }
    }
}
