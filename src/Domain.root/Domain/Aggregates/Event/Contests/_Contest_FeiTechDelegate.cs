using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
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
