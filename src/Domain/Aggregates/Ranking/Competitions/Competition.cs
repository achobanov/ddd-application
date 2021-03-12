using EnduranceJudge.Domain.Aggregates.Ranking.Participations;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;

namespace EnduranceJudge.Domain.Aggregates.Ranking.Competitions
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
