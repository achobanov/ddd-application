using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Models.Contests.ContestWorkers
{
    public class ContestWorkerException : DomainException
    {
        protected override string Entity { get; } = nameof(ContestWorker);
    }
}
