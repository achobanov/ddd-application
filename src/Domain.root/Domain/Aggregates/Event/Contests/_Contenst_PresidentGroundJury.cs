using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
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
