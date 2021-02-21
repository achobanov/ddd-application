using EnduranceContestManager.Domain.Aggregates.Ranking.Participations;
using EnduranceContestManager.Domain.Core.Validation;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Trials
{
    public class Trial : DomainModel<RankingTrialException>
    {
        internal Trial(int lengthInKilometers, List<Participation> participations) : base(default)
        {
            this.Participations = participations;
            this.LengthInKilometers = lengthInKilometers.IsRequired(nameof(lengthInKilometers));
        }

        public int LengthInKilometers { get; private set; }

        internal List<Participation> Participations { get; private set; }
    }
}
