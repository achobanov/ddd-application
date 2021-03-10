using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel
{
    public interface IPersonnelState : IDomainModelState
    {
        public string Name { get; }
    }
}
