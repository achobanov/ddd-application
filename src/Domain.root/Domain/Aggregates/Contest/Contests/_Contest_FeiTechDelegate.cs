using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public Personnel FeiTechDelegate { get; private set; }

        public Contest SetFeiTechDelegate(Personnel personnel)
        {
            this.Set(
                contest => contest.FeiTechDelegate,
                (contest, p) => contest.FeiTechDelegate = p,
                personnel);

            return this;
        }
    }
}
