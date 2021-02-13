using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests;
using EnduranceContestManager.Domain.Models.Phases;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Models.Trials
{
    public class Trial : DomainModel, ITrialState, IAggregateRoot
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
            this.Contest.CheckNotNullAndSet<Contest, TrialException>(contest);
            return this;
        }

        public Trial ClearContest()
        {
            this.Contest = null;
            return this;
        }

        public Trial AddPhase(Phase phase)
        {
            this.Phases.CheckExistingAndAdd<Phase, TrialException>(phase);
            phase.SetTrial(this);
            return this;
        }
    }
}
