using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public ContestWorker PresidentGroundJury { get; private set; }

        public Contest SetPresidentGroundJury(ContestWorker personnel)
        {
            this.Set(
                this,
                contest => contest.PresidentGroundJury,
                (contest, p) => contest.PresidentGroundJury = p,
                personnel);

            return this;
        }
    }
}
