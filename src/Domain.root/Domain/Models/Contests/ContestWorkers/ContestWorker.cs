using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;

namespace EnduranceContestManager.Domain.Models.Contests.ContestWorkers
{
    public class ContestWorker : DomainModel, IContestWorkerState
    {
        public ContestWorker(int id, string name)
            : base(id)
        {
            this.Name = name.CheckPersonName<ContestWorkerException>();
        }

        public string Name { get; private set; }

        public Contest Contest { get; private set; }

        public ContestWorker SetContest(Contest contest)
        {
            this.Contest.CheckNotNullAndSet<Contest, ContestWorkerException>(contest);
            return this;
        }

        public ContestWorker ClearContest()
        {
            this.Contest = null;
            return this;
        }
    }
}
