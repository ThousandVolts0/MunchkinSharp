using Munchkin;
using Munchkin.Events;
using Munchkin.Effects;
using Munchkin.Cards;
using Munchkin.IO;

namespace MunchkinProgram{
    internal class Program
    {
        static void Main(string[] args)
        {
            MunchkinGame game = new MunchkinGame(new GameSettings()
            {
                IOProvider = new ConsoleIO(),
                PlayerNames = PromptPlayerNameSelect(PromptPlayerAmountSelect())
            });
            game.Start();
        }


        private static int PromptPlayerAmountSelect()
        {
            Console.Write("Select amount of players: ");
            while (true)
            {
                string input = Console.ReadLine() ?? "";

                if (input.Any() && int.TryParse(input, out int result))
                    return result;

                Console.Write("Invalid input, try again: ");
            }
        }

        private static List<string> PromptPlayerNameSelect(int playerAmount)
        {
            List<string> playerNames = new();
            int playersLeft = playerAmount;
            while (playersLeft > 0)
            {
                Console.Write($"Enter name for player {playerAmount - playersLeft + 1}: ");
                string playerName = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.WriteLine("Player name cannot be empty, try again.");
                    continue;
                }

                playerNames.Add(playerName);
                playersLeft--;
            }

            return playerNames;
        }
    }
}
