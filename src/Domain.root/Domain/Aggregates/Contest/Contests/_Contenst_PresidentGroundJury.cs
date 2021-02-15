using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public Personnel PresidentGroundJury { get; private set; }

        public Contest SetPresidentGroundJury(Personnel personnel)
        {
            this.Set(
                contest => contest.PresidentGroundJury,
                (contest, p) => contest.PresidentGroundJury = p,
                personnel);

            return this;
        }
    }
}
