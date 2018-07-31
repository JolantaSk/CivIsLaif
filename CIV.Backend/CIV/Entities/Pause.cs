using System;

namespace CIV.Entities
{
    public class Pause : IEntity<Guid>
    {
        public Pause()
        {
            Id = Guid.NewGuid();
            StartedOn = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; private set; }
        public DateTimeOffset StartedOn { get; private set; }
        public DateTimeOffset? StopedOn { get; private set; }

        public void Stop()
        {
            StartedOn = DateTimeOffset.UtcNow;
        }
    }
}
