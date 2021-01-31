using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Entities.Trials
{
    public class Trial : Entity, ITrialState, IAggregateRoot
    {
        public Trial(int id, int lengthInKilometers, int durationInDays, IList<Phase> phases)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.DurationInDays = durationInDays;
            this.Phases = phases;
        }

        public int LengthInKilometers { get; private set;  }

        public int DurationInDays { get; private set; }

        public IList<Phase> Phases { get; private set; }
    }
}
