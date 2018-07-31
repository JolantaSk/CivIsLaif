using System;
using System.Collections.Generic;
using System.Linq;

namespace CIV.Entities
{
    public class ActivePhase
    {
        private List<PlayerTurn> _playerTurns = new List<PlayerTurn>();

        public ActivePhase(Guid phaseId)
        {
            Id = Guid.NewGuid();
            PhaseId = phaseId;
        }

        public Guid Id { get; private set; }
        public Guid PhaseId { get; }
        public Phase Phase { get; private set; }

        public static ActivePhase Create(Phase phase, TurnOrder turnOrder)
        {
            var playerTurns = turnOrder.CreatePlayerTurns(phase.SimultaniousTurns);
            var activePhase = new ActivePhase(phase.Id)
            {
                Phase = phase
            };
            activePhase._playerTurns.AddRange(playerTurns);
            return activePhase;
        }
        
        public void FinishPlayerTurn(string userName)
        {
            var playerTurn = GetPlayerTurn(userName);
            if (playerTurn != null)
            {
                throw new InvalidOperationException("Cannot finish turn");
            }
            playerTurn.Finish();
        }

        private PlayerTurn GetPlayerTurn(string userName)
        {
            return _playerTurns.Find(t => t.Player.UserName == userName);
        }

        public ActivePhase Next(TurnOrder turnOrder)
        {
            return Create(Phase.NextPhase, turnOrder);
        }

        public bool TurnsFinished => _playerTurns.All(t => t.IsFinished);
    }

}
