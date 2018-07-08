using System;
using System.Collections.Generic;

namespace CIV
{
    public class Game
    {
        private List<Player> _players = new List<Player>();

        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Player> Players => _players.AsReadOnly();
        public Player AddPlayer(string username)
        {
            var player = new Player(username);
            _players.Add(player);
            return player;
        }
    }
}
