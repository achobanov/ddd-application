using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Contest.Contests;
using EnduranceContestManager.Domain.Aggregates.Contest.Phases;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Trials
{
    public class Trial : DomainModel<TrialException>, ITrialState, IAggregateRoot,
        IDependsOn<Contests.Contest>
    {
        public Trial(int id, int lengthInKilometers, int durationInDays)
            : base(id)
        {
            this.Except(() =>
            {
                this.LengthInKilometers = lengthInKilometers.CheckNotDefault(nameof(lengthInKilometers));
                this.DurationInDays = durationInDays.CheckNotDefault(nameof(durationInDays));
            });
        }

        public int LengthInKilometers { get; private set;  }

        public int DurationInDays { get; private set; }

        public Contests.Contest Contest { get; private set; }

        public List<Phase> Phases { get; private set; } = new();

        void IDependsOn<Contests.Contest>.Set(Contests.Contest domainModel)
            => this.Except(() =>
            {
                this.Contest.CheckNotRelated();
                this.Contest = domainModel;
            });

        void IDependsOn<Contests.Contest>.Clear(Contests.Contest domainModel)
        {
            this.Contest = null;
        }
    }
}
