using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public interface IContestState : IDomainModelState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }

        public string Country { get; }
    }
}
