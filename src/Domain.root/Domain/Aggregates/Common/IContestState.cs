using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Common
{
    public interface IContestState : IDomainModelState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }
    }
}
