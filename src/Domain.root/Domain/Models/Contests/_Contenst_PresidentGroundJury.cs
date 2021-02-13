using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public ContestWorker PresidentGroundJury { get; private set; }

        public Contest SetPresidentGroundJury(ContestWorker worker)
        {
            this.PresidentGroundJury = worker.SetContest(this);
            return this;
        }
    }
}
