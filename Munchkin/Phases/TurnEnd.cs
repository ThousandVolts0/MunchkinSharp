using Munchkin.IO;
using Munchkin.Services;

namespace Munchkin.Phases
{
    public class TurnEnd : IGamePhase
    {
        private TurnContext _turncontext;
        private GameServices _services;
        private GameSettings _settings;
        public TurnEnd(TurnContext turnContext, GameServices services, GameSettings settings)
        {
            _turncontext = turnContext;
            _services = services;
            _settings = settings;
        }

        public IGamePhase Run()
        {
            IIOProvider io = _settings.IOProvider;
            Player player = _turncontext.ActivePlayer;
            bool hasTooManyCards = _turncontext.ActivePlayer.Hand.Count > 5;

            if (hasTooManyCards)
            {
                io.Clear();
                while (true)
                {
                    io.Write($"You have { player.Hand.Count} cards in your hand. Please discard down to 5.");
                    for (int i = 0; i < player.Hand.Count; i++)
                    {
                        io.Write($"{i + 1}. {player.Hand[i].Definition.Name}");
                    }

                    string input = io.Read();
                    if (int.TryParse(input, out int index) && index >= 1 && index <= player.Hand.Count)
                    {
                        player.Hand.RemoveAt(index - 1);
                        io.Write("Card discarded.");
                        io.Write("Press any key to continue...");
                        io.Read();
                        if (player.Hand.Count <= 5)
                        {
                            break;
                        }
                    }
                    else
                    {
                        io.Write("Invalid input. Please enter a valid card number to discard.");
                        io.Write("Press any key to continue...");
                        io.Read();
                    }
                }
            }

            io.Write("Turn ended. Press any key to continue...");
            io.Read();
            _services.Get<TurnService>().AdvanceTurn();
            return new TurnBegin(new TurnContext(_services.Get<TurnService>().CurrentPlayer), _services, _settings);
        }
    }
}
