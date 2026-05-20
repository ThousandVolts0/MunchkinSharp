using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Events;

namespace Munchkin.Systems
{
    public class TurnSystem
    {
        public IReadOnlyList<Player> Players { get; private set; }
        public Player CurrentPlayer => Players[_currentPlayerIndex];
        private int _currentPlayerIndex = 0;

        public TurnSystem(IReadOnlyList<Player> players)
        {
            Players = players;
        }

        public TurnSystem(List<Player> players)
        {
            Players = players.AsReadOnly();
        }

        private int GetNextPlayerIndex()
        {
            return (_currentPlayerIndex + 1) % Players.Count;
        }

        public void AdvanceTurn()
        {
            _currentPlayerIndex = GetNextPlayerIndex();
        }
    }
}
