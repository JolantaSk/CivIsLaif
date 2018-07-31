using System;
using System.Collections.Generic;
using System.Linq;

namespace CIV.Entities
{
    public class Phase : IEntity<Guid>
    {
        private Phase(string name, Guid? nextPhaseId)
        {
            Id = Guid.NewGuid();
            Name = name;
            NextPhaseId = nextPhaseId;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public Guid? NextPhaseId { get; }
        public Phase NextPhase { get; private set; }

        private static Phase Create(string name, Phase nextPhase)
        {
            return new Phase(name, nextPhase?.Id)
            {
                NextPhase = nextPhase
            };
        }

        public static Phase Create(IEnumerable<string> names)
        {
            var name = names.FirstOrDefault();
            if (name == null)
            {
                return null;
            }
            return Create(name, Create(names.Skip(1)));
        }

        public Phase First() => All().First();

        public IEnumerable<Phase> All()
        {
            do
            {
                yield return NextPhase;
            }
            while (!NextPhase.IsLastOfAll());
        }

        public bool IsLastOfAll() => NextPhase == null;

        public bool SimultaniousTurns { get; set; }
    }
}
