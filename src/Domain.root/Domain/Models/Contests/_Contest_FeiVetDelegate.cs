using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker FeiVetDelegate { get; private set; }

        public Contest SetFeiVetDelegate(ContestWorker personnel)
        {
            this.Set(
                contest => contest.FeiVetDelegate,
                (contest, p) => contest.FeiVetDelegate = p,
                personnel);

            return this;
        }
    }
}
