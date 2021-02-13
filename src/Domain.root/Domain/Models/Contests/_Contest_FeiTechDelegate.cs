using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker FeiTechDelegate { get; private set; }

        public Contest SetFeiTechDelegate(ContestWorker worker)
        {
            this.FeiTechDelegate = worker.SetContest(this);
            return this;
        }
    }
}
