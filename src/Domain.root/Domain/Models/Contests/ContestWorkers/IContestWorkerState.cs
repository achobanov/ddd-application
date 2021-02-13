using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Models.Contests.ContestWorkers
{
    public interface IContestWorkerState : IDomainModelState
    {
        public string Name { get; }
    }
}
