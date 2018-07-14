using System;
using System.Collections.Generic;
using System.Linq;

namespace CIV.Entities
{
    public class Game: IEntity<Guid>
    {
        private List<Player> _players = new List<Player>();

        private Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public static Game Create(string name, Player creator)
        {
            var game = new Game(name)
            {
                Creator = creator
            };
            return game;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Player Creator { get; private set; }
        public IReadOnlyCollection<Player> Players => _players.AsReadOnly();
        public void AddPlayer(Player player)
        {
            if (HasPlayer(player.UserName))
            {
                throw new InvalidOperationException(
                    $"Player with the same name already exist '{player.UserName}'");
            }
            _players.Add(player);
        }

        public bool HasPlayer(string username)
        {
            return _players.Any(p => p.UserName == username);
        }

        public IEnumerable<string> PlayerUserNames => _players.Select(p => p.UserName);
    }
}
