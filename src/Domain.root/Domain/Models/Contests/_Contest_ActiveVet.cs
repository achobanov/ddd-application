using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker ActiveVet { get; private set; }

        public Contest SetActiveVet(ContestWorker worker)
        {
            this.ActiveVet = worker.SetContest(this);
            return this;
        }
    }
}
