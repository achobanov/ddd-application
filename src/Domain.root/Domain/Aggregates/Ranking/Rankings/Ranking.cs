using EnduranceContestManager.Domain.Aggregates.Ranking.Classifications;
using EnduranceContestManager.Domain.Aggregates.Ranking.Competitions;
using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Rankings
{
    public class Ranking : DomainModel<RankingException>, IAggregateRoot
    {
        private readonly List<Classification> classifications = new();

        public Ranking(IReadOnlyCollection<Competition> competitions) : base(default)
        {
            foreach (var competition in competitions)
            {
                var kidsClassification = new Classification(Category.Kids, competition);
                var adultsClassification = new Classification(Category.Adults, competition);

                this.classifications.Add(kidsClassification);
                this.classifications.Add(adultsClassification);
            }
        }

        public IReadOnlyList<Classification> Classifications => this.classifications.AsReadOnly();
    }
}
