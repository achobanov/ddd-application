using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public Personnel ForeignJudge { get; private set; }

        public Contest SetForeignJudge(Personnel personnel)
        {
            this.Set(
                contest => contest.ForeignJudge,
                (contest, p) => contest.ForeignJudge = p,
                personnel);

            return this;
        }
    }
}
