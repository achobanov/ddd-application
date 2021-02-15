using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel
{
    public interface IPersonnelState : IDomainModelState
    {
        public string Name { get; }
    }
}
