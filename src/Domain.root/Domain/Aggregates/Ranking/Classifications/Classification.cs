using EnduranceContestManager.Domain.Aggregates.Ranking.Participations;
using EnduranceContestManager.Domain.Aggregates.Ranking.Trials;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Classifications
{
    public class Classification : DomainModel<ClassificationException>
    {
        internal Classification(Category category, Trial trial) : base(default)
        {
            this.Validate(() =>
            {
                this.Category = category.IsRequired(nameof(category));
            });

            this.LengthInKilometers = trial.LengthInKilometers;
            this.RankList = this.Classify(trial.Participations);
        }

        public int LengthInKilometers { get; }
        public Category Category { get; private set; }
        public IReadOnlyList<Participation> RankList { get; private set; }

        private List<Participation> Classify(IReadOnlyList<Participation> participations)
        {
            var qualified = participations.Where(x => x.Category == this.Category && x.IsRanked);

            var ranked = this.Category == Category.Kids
                ? qualified.OrderBy(participation => participation.RecoverySpanInTicks)
                : qualified.OrderBy(participation => participation.FinalTime);

            return ranked.ToList();
        }
    }
}
