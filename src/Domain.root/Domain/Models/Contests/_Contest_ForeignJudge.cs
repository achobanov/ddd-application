using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public ContestWorker ForeignJudge { get; private set; }

        public Contest SetForeignJudge(ContestWorker worker)
        {
            this.ForeignJudge = worker.SetContest(this);
            return this;
        }
    }
}
