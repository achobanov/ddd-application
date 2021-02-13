using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public ContestWorker ActiveVet { get; private set; }

        public Contest SetActiveVet(ContestWorker worker)
        {
            this.ActiveVet = worker.SetContest(this);
            return this;
        }
    }
}
