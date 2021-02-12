using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Domain.Entities.Phases;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Entities.Trials
{
    public class Trial : Entity, ITrialState, IAggregateRoot
    {
        public Trial(int id, int lengthInKilometers, int durationInDays)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.DurationInDays = durationInDays;
        }

        public int LengthInKilometers { get; private set;  }

        public int DurationInDays { get; private set; }

        public Contest Contest { get; private set; }

        public IList<Phase> Phases { get; private set; } = new List<Phase>();

        public Trial SetContest(Contest contest)
        {
            this.Contest = contest;
            return this;
        }

        public Trial ClearContest()
        {
            this.Contest = null;
            return this;
        }

        public Trial AddPhase(Phase phase)
        {
            if (phase is FinalPhase finalPhase && this.Phases.Any(x => x is FinalPhase))
            {
                Thrower.Throw<TrialException>("cannot add phase: Final phase already exists");
            }

            this.Phases.Add(phase);
            return this;
        }
    }
}
