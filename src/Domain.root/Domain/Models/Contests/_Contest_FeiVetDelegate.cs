using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public ContestWorker FeiVetDelegate { get; private set; }

        public Contest SetFeiVetDelegate(ContestWorker worker)
        {
            this.FeiVetDelegate = worker.SetContest(this);
            return this;
        }
    }
}
