using NullGuard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIV.Entities
{
    public class Game: IEntity<Guid>
    {
        private List<Player> _players = new List<Player>();
        private List<Pause> _pauses = new List<Pause>();

        private Game(string name, string creatorId)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatorId = creatorId;
        }

        public static Game Create(string name, Player creator)
        {
            return new Game(name, creator.Id)
            {
                Creator = creator
            };
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Game TurnOrder { get; }
        public bool IsPaused { get; private set; }
        public string CreatorId { get; }
        public Player Creator { [return: AllowNull] get; private set; }
        public Turn Turn { [return: AllowNull] get; private set; }

        public bool IsStarted => Turn != null;
        public IReadOnlyCollection<Pause> Pauses => _pauses.AsReadOnly();
        public IReadOnlyCollection<Player> Players => _players.AsReadOnly();
        public IEnumerable<string> PlayerUserNames => _players.Select(p => p.UserName);

        public void AddPlayer(Player player)
        {
            if (HasPlayer(player.UserName))
            {
                throw new InvalidOperationException(
                    $"Player with the same name already exist '{player.UserName}'");
            }
            _players.Add(player);
        }

        public void Start(TurnOrder turnOrder, Phase firstPhase)
        {
            Turn = Turn.Create(turnOrder, firstPhase);
        }

        public void Pause()
        {
            if (IsPaused == true)
            {
                throw new InvalidOperationException("Cannot pause already paused game");
            }
            IsPaused = true;
            _pauses.Add(new Pause());
        }

        public void Unpause()
        {
            if(IsPaused == false || !_pauses.Any(p => !p.StopedOn.HasValue))
            {
                throw new InvalidOperationException("Cannot unpause not paused game");
            }
            IsPaused = false;
            var pause = _pauses.SingleOrDefault(p => !p.StopedOn.HasValue);
            pause.Stop();
        }

        public void FinishPlayerTurn(string userName)
        {
            Turn.Finish(userName);
            if (Turn.Finished)
            {
                Turn = Turn.Next();
            }
        }

        public bool HasPlayer(string userName)
        {
            return _players.Any(p => p.UserName == userName);
        }
    }
}
