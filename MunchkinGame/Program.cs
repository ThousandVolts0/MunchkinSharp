using Munchkin;
using Munchkin.Events;
using Munchkin.Effects;
using Munchkin.Cards;
using Munchkin.IO;
using System.Diagnostics.SymbolStore;

namespace MunchkinProgram{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSettings settings = new()
            { 
                IOProvider = new ConsoleIOProvider(), 
                Players = MunchkinBootstrap.SetupPlayers()
            };

            MunchkinGame game = new MunchkinGame(settings);
            game.Start();
            while (game.IsRunning)
            {
                game.NextPhase();
            }
        }
    }
}
