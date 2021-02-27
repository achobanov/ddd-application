using EnduranceContestManager.Domain.Aggregates.Ranking.Participations;
using EnduranceContestManager.Domain.Aggregates.Ranking.Trials;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Classifications
{
    public class Classification : DomainModel<ClassificationException>
    {
        private readonly List<Participation> rankList;

        internal Classification(Category category, Trial trial) : base(default)
        {
            this.Category = category;
            this.LengthInKilometers = trial.LengthInKilometers;

            // TODO: Modify classification logic for Kids -
            // instead of sort by FinalTime we sort them by
            // the SHORTEST SUM OF REST TIME on each phase.
            this.rankList = trial.Participations
                .Where(x => x.Category == category && x.IsRanked)
                .OrderBy(x => x.FinalTime)
                .ToList();
        }

        public int LengthInKilometers { get; }
        public Category Category { get; }

        public IReadOnlyList<Participation> RankList => this.rankList.AsReadOnly();
    }
}
