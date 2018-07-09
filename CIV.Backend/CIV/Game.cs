using System;
using System.Collections.Generic;
using System.Linq;

namespace CIV
{
    public class Game
    {
        private List<Player> _players = new List<Player>();

        public Game(string name, string creator)
        {
            Id = Guid.NewGuid();
            Creator = new Player(creator);
            _players.Add(Creator);
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Player Creator { get; private set; }
        public IReadOnlyCollection<Player> Players => _players.AsReadOnly();
        public Player AddPlayer(string username)
        {
            if (HasPlayer(username))
            {
                throw new InvalidOperationException(
                    $"Player with the same name already exist '{username}'");
            }
            var player = new Player(username);
            _players.Add(player);
            return player;
        }

        public bool HasPlayer(string username)
        {
            return _players.Any(p => p.Username == username);
        }
    }
}
