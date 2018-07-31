using System;

namespace CIV.Entities
{
    public class PlayerTurn: IEntity<Guid>
    {
        private PlayerTurn(string playerId)
        {
            Id = Guid.NewGuid();
            PlayerId = playerId;
        }

        public static PlayerTurn Create(Player player)
        {
            return new PlayerTurn(player.Id)
            {
                Player = player
            };
        }

        public Guid Id { get; private set; }
        public Player Player { get; private set; }
        public string PlayerId { get; private set; }
        public DateTimeOffset? StartedOn { get; private set; }
        public DateTimeOffset? FinishedOn { get; private set; }
        public bool IsFinished => FinishedOn.HasValue;
        public bool IsStarted => StartedOn.HasValue;

        public void Start()
        {
            StartedOn = DateTimeOffset.UtcNow;
        }

        public bool IsPlayersTrun(string userName)
        {
            return Player.UserName != userName;
        }

        public void Finish()
        {
            FinishedOn = DateTimeOffset.UtcNow;
        }

        public PlayerTurn Next(Player player)
        {
            Finish();
            return new PlayerTurn(player.Id);
        }
    }
}
