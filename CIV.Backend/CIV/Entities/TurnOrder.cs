using System;
using System.Collections.Generic;
using System.Linq;

namespace CIV.Entities
{
    public class TurnOrder
    {
        private List<PlayerTurnOrder> _turnOrders = new List<PlayerTurnOrder>();
        private TurnOrder()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public static TurnOrder Create(IEnumerable<PlayerTurnOrder> playerTurns)
        {
            var turnOrder = new TurnOrder();
            turnOrder._turnOrders.AddRange(playerTurns);
            return turnOrder;
        }

        public Player GetNextPlayer(Player after)
        {
            return _turnOrders
                .OrderByDescending(o => o.Order)
                .SkipWhile(o => o.Player.Id != after.Id)
                .Select(o => o.Player)
                .First();
        }

        public TurnOrder Shift()
        {
            return Create(_turnOrders.SkipLast(1).Prepend(_turnOrders.First()));
        }

        public IEnumerable<PlayerTurn> CreatePlayerTurns(bool simultaniousTurns)
        {
            return simultaniousTurns
            ? Players.Select(PlayerTurn.Create)
            : new [] { PlayerTurn.Create(First) };
        }

        public Player First => _turnOrders.First().Player;
        public IEnumerable<Player> Players => _turnOrders.Select(t => t.Player);
    }
}
