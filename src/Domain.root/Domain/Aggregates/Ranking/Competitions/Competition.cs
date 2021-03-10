using EnduranceContestManager.Domain.Aggregates.Ranking.Participations;
using EnduranceContestManager.Domain.Core.Validation;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Competitions
{
    public class Competition : DomainModel<RankingCompetitionException>
    {
        private readonly List<Participation> participations = new();

        public Competition() : base(default)
        {
        }

        public int LengthInKilometers { get; private set; }
        public IReadOnlyList<Participation> Participations => this.participations.AsReadOnly();
    }
}
