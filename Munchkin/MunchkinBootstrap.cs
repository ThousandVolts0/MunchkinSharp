using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.IO;
using Munchkin.Systems;

namespace Munchkin
{
    public static class MunchkinBootstrap
    {
        internal static GameServices GetGameServices(GameSettings gameSettings)
        {
            EffectDispatcher effectDispatcher = new EffectDispatcher();
            TurnService turnService = new TurnService(gameSettings.Players);
            CardService cardService = new CardService(effectDispatcher);
            GameServices services = new GameServices();
            //_systems.EffectDispatcher = new EffectDispatcher(_api);
            //_systems.TurnSystem = new TurnSystem(_state.Players);
            //_systems.CardSystem = new CardSystem(_systems.EffectDispatcher);

            throw new NotImplementedException();
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
