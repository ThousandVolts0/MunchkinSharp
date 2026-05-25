using Munchkin.Cards;
using Munchkin.Events;
using Munchkin.IO;
using Munchkin.Services;

namespace Munchkin.Phases
{
    public class TurnBegin : IGamePhase
    {
        private TurnContext _turncontext; 
        private GameServices _services;
        private GameSettings _settings;
        public TurnBegin(TurnContext turnContext, GameServices services, GameSettings settings)
        {
            _turncontext = turnContext;
            _services = services;
            _settings = settings;
        }

        public IGamePhase Run()
        {
            Player player = _turncontext.ActivePlayer;
            IIOProvider io = _settings.IOProvider;
            CardInteractionService cardService = _services.Get<CardInteractionService>();
            EffectDispatchService effectService = _services.Get<EffectDispatchService>();
            DeckService deckService = _services.Get<DeckService>();
            CombatService combatService = _services.Get<CombatService>();
            bool turnEnded = false;

            while (!turnEnded)
            {
                io.Clear();
                io.Write($"{player.Name}'s turn\n");
                io.Write($"1. Show cards in hand");
                io.Write($"2. Play cards in hand");
                io.Write($"3. Kick open the door");

                string input = _settings.IOProvider.Read();
                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            io.Clear();
                            io.Write("Cards in hand:");
                            for (int i = 0; i < player.Hand.Count; i++)
                            {
                                io.Write($"{i + 1}. {player.Hand[i].Definition.Name}");
                            }
                            io.Write("Press any key to continue...");
                            io.Read();
                            continue;
                        case 2:
                            io.Clear();
                            io.Write("Playing cards is not implemented yet.");
                            io.Write("Press any key to continue...");
                            io.Read();
                            continue;
                        case 3:
                            CardInstance card = deckService.Draw(CardType.Door);
                            effectService.Invoke(new OnDoorOpen { Card = card, Player = player });
                            cardService.AddToHand(card, player);
                            io.Clear() ;
                            io.Write($"You kicked open the door and found: {card.Definition.Name}");
                            io.Write("Press any key to continue...");
                            io.Read();

                            if (combatService.ShouldStartCombat(card))
                            {
                                return new CombatBegin(new CombatContext(player, card), _services, _settings);
                            }

                            turnEnded = true;
                            break;
                    }
                }
                io.Write("Invalid input, try again.");
                io.Write("Press any key to continue...");
                io.Read();
                break;
            }

            io.Write("Ending turn");
            io.Write("Press any key to continue...");
            io.Read();

            TurnContext context = new(player);
            return new TurnEnd(context, _services, _settings);
        }
    }
}
