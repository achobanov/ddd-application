using EnduranceContestManager.Domain.Aggregates.Ranking.ResultsInPhases;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Participations
{
    public class Participation : DomainModel<RankingParticipationException>
    {
        private const string MissingFinalPhase = "Invalid participation - missing result for Final phase.";

        private readonly List<ResultInPhase> resultsInPhases = new();

        internal Participation() : base(default)
        {
        }

        public Category Category { get; private set; }
        public IReadOnlyList<ResultInPhase> ResultsInPhases => this.resultsInPhases.AsReadOnly();

        public bool IsRanked
            => this.ResultsInPhases.All(x => x.IsRanked);

        public DateTime FinalTime
        {
            get
            {
                var finalPhase = this.ResultsInPhases
                    .SingleOrDefault(x => x.IsFinalPhase)
                    .IsNotDefault(MissingFinalPhase);

                return finalPhase.ArrivalTime;
            }
        }
    }
}
