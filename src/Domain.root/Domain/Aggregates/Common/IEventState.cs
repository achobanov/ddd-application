using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Common
{
    public interface IEventState : IDomainModelState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }
    }
}
