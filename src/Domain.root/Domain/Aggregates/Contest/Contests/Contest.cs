using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest : DomainModel<ContestException>, IContestState, IAggregateRoot
    {
        public Contest(int id, string name, string populatedPlace, string country) : base(id)
            => this.Except(() =>
            {
                this.Name = name.IsRequired(nameof(name));
                this.PopulatedPlace = populatedPlace.IsRequired(nameof(populatedPlace));
                this.Country = country.IsRequired(nameof(country));
            });

        public string Name { get; private set; }
        public string PopulatedPlace { get; private set; }
        public string Country { get; private set; }
    }
}
