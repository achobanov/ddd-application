using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest : DomainModel<ContestException>, IContestState, IAggregateRoot
    {
        public Contest(int id, string name, string populatedPlace, string country)
            : base(id)
        {
            this.Name = name;
            this.PopulatedPlace = populatedPlace;
            this.Country = country;
        }

        public string Name { get; private set; }

        public string PopulatedPlace { get; private set; }

        public string Country { get; private set; }
    }
}
