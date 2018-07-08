using System;
using System.Collections.Concurrent;
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

        public static Guid AddGame(string name)
        {
            var game = new Game(name);
            lock (_lock)
            {
               _games.Add(game);
            }
            _gameAdded.OnNext(name);
            return game.Id;
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

        public static IObservable<string> Games => _gameAdded;
    }
}
