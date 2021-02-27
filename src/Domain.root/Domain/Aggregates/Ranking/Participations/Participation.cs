using EnduranceContestManager.Domain.Aggregates.Ranking.ResultsInPhases;
using EnduranceContestManager.Domain.Aggregates.Ranking.Trials;
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

        public Participation(Category category, List<ResultInPhase> resultsInPhases) : base(default)
            => this.Validate(() =>
            {
                // Add validation for single final phase.
                this.Category = category.IsRequired(nameof(category));
                this.ResultsInPhases = resultsInPhases;
            });

        public Category Category { get; private set; }

        public bool IsRanked
        {
            get
            {
                return this.ResultsInPhases.All(x => x.IsRanked);
            }
        }

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

        private List<ResultInPhase> ResultsInPhases { get; set; }
    }
}
