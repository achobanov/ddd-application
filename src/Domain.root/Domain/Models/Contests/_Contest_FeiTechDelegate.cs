using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public ContestWorker FeiTechDelegate { get; private set; }

        public Contest SetFeiTechDelegate(ContestWorker worker)
        {
            this.FeiTechDelegate = worker.SetContest(this);
            return this;
        }
    }
}
