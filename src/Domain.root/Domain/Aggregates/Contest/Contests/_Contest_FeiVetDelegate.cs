using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public Personnel FeiVetDelegate { get; private set; }

        public Contest SetFeiVetDelegate(Personnel personnel)
        {
            this.Set(
                contest => contest.FeiVetDelegate,
                (contest, p) => contest.FeiVetDelegate = p,
                personnel);

            return this;
        }
    }
}
