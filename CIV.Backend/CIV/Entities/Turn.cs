using System;
using System.Collections.Generic;

namespace CIV.Entities
{
    public class Turn: IEntity<Guid>
    {
        private List<PlayerTurn> _playerTurns = new List<PlayerTurn>();

        private Turn(Guid turnOrderId, Guid currentPhaseId)
        {
            Id = Guid.NewGuid();
            TurnOrderId = turnOrderId;
            CurrentPhaseId = currentPhaseId;
        }

        public static Turn Create(TurnOrder turnOrder, Phase firstPhase)
        {
            var activePhase = ActivePhase.Create(firstPhase, turnOrder);
            return new Turn(turnOrder.Id, activePhase.Id)
            {
                TurnOrder = turnOrder,
                CurrentPhase = activePhase
            };
        }

        public void Finish(string userName)
        {
            CurrentPhase.FinishPlayerTurn(userName);
            if (CurrentPhase.TurnsFinished)
            {
                CurrentPhase = CurrentPhase.Next(TurnOrder);
            }
        }

        public Turn Next()
        {
            return Create(TurnOrder.Shift(), CurrentPhase.Phase.First());
        }

        public Guid Id { get; private set; }
        public Guid CurrentPhaseId { get; private set; }
        public ActivePhase CurrentPhase { get; private set; }
        public Guid TurnOrderId { get; private set; }
        public TurnOrder TurnOrder { get; private set; }
        public bool Finished => CurrentPhase.Phase.IsLastOfAll() && CurrentPhase.TurnsFinished;
    }
}
