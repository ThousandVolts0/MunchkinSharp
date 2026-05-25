using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.IO;
using Munchkin.Services;

namespace Munchkin
{
    public static class MunchkinBootstrap
    {
        internal static GameServices CreateGameServices(GameSettings gameSettings)
        {
            GameServices services = new GameServices();
            GameAPI gameApi = new GameAPI(services);
            EffectDispatchService effectDispatcher = new EffectDispatchService(gameApi);
            TurnService turnService = new TurnService(gameSettings.Players);
            CardInteractionService cardService = new CardInteractionService(effectDispatcher);
            DeckService deckService = new DeckService();
            CombatService combatService = new CombatService();

            services.Register(effectDispatcher);
            services.Register(turnService);
            services.Register(cardService);
            services.Register(deckService);
            services.Register(combatService);
            return services;
        }

        public static List<Player> SetupPlayers(IIOProvider? ioProvider = null)
        {
            IIOProvider io = ioProvider ?? new ConsoleIOProvider();
            int playerAmount = IOHelpers.PromptPlayerAmountSelect(io);
            return IOHelpers.PromptPlayerCreation(playerAmount, io);
        }

        public static GameSettings GetDefaultSettings()
        {
            List<Player> players = new();
            for (int i = 0; i < 4; i++)
            {
                players.Add(new Player { Name = $"Player {i + 1}" });
            }

            return new GameSettings
            {
                IOProvider = new ConsoleIOProvider(),
                Players = players
            };
        }

    }
}
