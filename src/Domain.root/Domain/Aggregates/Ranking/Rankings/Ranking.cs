using EnduranceContestManager.Domain.Aggregates.Ranking.Classifications;
using EnduranceContestManager.Domain.Aggregates.Ranking.Trials;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Rankings
{
    public class Ranking : DomainModel<RankingException>
    {
        private readonly List<Classification> classifications = new();

        public Ranking(IReadOnlyCollection<Trial> trials) : base(default)
        {
            foreach (var trial in trials)
            {
                var kidsClassification = new Classification(Category.Kids, trial);
                var adultsClassification = new Classification(Category.Adults, trial);

                this.classifications.Add(kidsClassification);
                this.classifications.Add(adultsClassification);
            }
        }

        public IReadOnlyList<Classification> Classifications => this.classifications;
    }
}
