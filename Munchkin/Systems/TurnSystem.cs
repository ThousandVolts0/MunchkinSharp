using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.Events;

namespace Munchkin.Systems
{
    public class TurnSystem
    {
        private readonly IReadOnlyList<Player> _players;

        public Player CurrentPlayer => _players[_currentPlayerIndex];
        private int _currentPlayerIndex = 0;

        public TurnSystem(IReadOnlyList<Player> players)
        {
            _players = players;
        }

        private int GetNextPlayerIndex()
        {
            return (_currentPlayerIndex + 1) % _players.Count;
        }

        public Player AdvanceTurn()
        {
            _currentPlayerIndex = GetNextPlayerIndex();
            return CurrentPlayer;
        }
    }
}
