using System;

namespace CIV.Entities
{
    public class PlayerTurnOrder
    {
        private PlayerTurnOrder(string playerId, int order)
        {
            _id = Guid.NewGuid();
            PlayerId = playerId;
            Order = order;
        }

        public static PlayerTurnOrder Create(Player player, int order)
        {
            return new PlayerTurnOrder(player.Id, order)
            {
                Player = player
            };
        }
        private Guid _id;
        public Player Player { get; private set; }
        public string PlayerId { get; private set; }
        public int Order { get; private set; }
    }
}
