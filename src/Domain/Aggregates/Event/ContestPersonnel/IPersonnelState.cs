using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel
{
    public interface IPersonnelState : IDomainModelState
    {
        public string Name { get; }
    }
}
