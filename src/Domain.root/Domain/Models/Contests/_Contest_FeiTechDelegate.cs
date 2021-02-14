using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker FeiTechDelegate { get; private set; }

        public Contest SetFeiTechDelegate(ContestWorker personnel)
        {
            this.Set(
                contest => contest.FeiTechDelegate,
                (contest, p) => contest.FeiTechDelegate = p,
                personnel);

            return this;
        }
    }
}
