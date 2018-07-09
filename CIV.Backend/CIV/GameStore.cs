using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;

namespace CIV
{
    public static class GameStore
    {
        private static object _lock = new object();
        private static List<Game> _games = new List<Game>();
        private const int CodeLength = 4;
        private static Subject<string> _gameAdded = new Subject<string>();

        public static Guid AddGame(string name, string creator)
        {
            var game = new Game(name, creator);
            lock (_lock)
            {
               _games.Add(game);
            }
            _gameAdded.OnNext(name);
            return game.Id;
        }

        public static string GetGameCreator(string name)
        {
            lock (_lock)
            {
                var game = _games.SingleOrDefault(g => g.Name == name);
                return game.Creator.Username;
            }
        }

        public static IEnumerable<string> GetPlayerNames(string name)
        {
            lock (_lock)
            {
                var game = _games.SingleOrDefault(g => g.Name == name);
                if(game == null)
                {
                    return Enumerable.Empty<string>();
                }
                return game.Players
                    .Select(e => e.Username)
                    .ToArray();
            }
        }

        public static Guid AddPlayer(string gameName, string username)
        {
            lock (_lock)
            {
                var game = _games.Single(g => g.Name == gameName);
                var player = game.AddPlayer(username);
                return player.Id;
            }
        }

        public static bool HasPlayer(string gameName, string username)
        {
            lock (_lock)
            {
                var game = _games.Single(g => g.Name == gameName);
                return game.HasPlayer(username);
            }
        }

        public static IObservable<string> Games => _gameAdded;
    }
}
