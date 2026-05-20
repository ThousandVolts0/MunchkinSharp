using Munchkin.Cards;
using Munchkin.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Systems
{
    public class CardSystem
    {
        private readonly EffectDispatcher _dispatcher;

        public CardSystem(EffectDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Draw(Player player, Deck deck)
        {
            CardInstance card = deck.Draw();
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
