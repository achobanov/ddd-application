using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests;
using EnduranceContestManager.Domain.Models.Phases;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Models.Trials
{
    public class Trial : DomainModel<TrialException>, ITrialState, IAggregateRoot,
        IDependsOn<Contest>
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

        public Contest Contest { get; private set; }

        public List<Phase> Phases { get; private set; } = new();

        void IDependsOn<Contest>.Set(Contest domainModel)
            => this.Except(() =>
            {
                this.Contest.CheckNotRelated();
                this.Contest = domainModel;
            });

        void IDependsOn<Contest>.Clear(Contest domainModel)
        {
            this.Contest = null;
        }
    }
}
