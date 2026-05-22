using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.IO
{
    internal static class IOHelpers
    {
        internal static int PromptPlayerAmountSelect(IIOProvider io)
        {
            io.Write("Select amount of players: ");
            while (true)
            {
                string input = io.Read() ?? "";

                if (input.Any() && int.TryParse(input, out int result))
                    return result;

                io.Write("Invalid input, try again: ");
            }
        }

        internal static List<Player> PromptPlayerCreation(int playerAmount, IIOProvider io)
        {
            List<Player> players = new();
            int playersLeft = playerAmount;
            while (playersLeft > 0)
            {
                io.Write($"Enter name for player {playerAmount - playersLeft + 1}: ");
                string playerName = io.Read() ?? "";
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    io.Write("Player name cannot be empty, try again.");
                    continue;
                }

                players.Add(new Player { Name = playerName });
                playersLeft--;
            }

            return players;
        }
    }
}
