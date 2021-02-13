using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker ForeignJudge { get; private set; }

        public Contest SetForeignJudge(ContestWorker worker)
        {
            this.ForeignJudge = worker.SetContest(this);
            return this;
        }
    }
}
