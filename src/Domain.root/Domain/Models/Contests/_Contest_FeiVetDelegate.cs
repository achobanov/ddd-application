using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker FeiVetDelegate { get; private set; }

        public Contest SetFeiVetDelegate(ContestWorker worker)
        {
            this.FeiVetDelegate = worker.SetContest(this);
            return this;
        }
    }
}
