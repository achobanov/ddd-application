using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker ForeignJudge { get; private set; }

        public Contest SetForeignJudge(ContestWorker personnel)
        {
            this.Set(
                contest => contest.ForeignJudge,
                (contest, p) => contest.ForeignJudge = p,
                personnel);

            return this;
        }
    }
}
