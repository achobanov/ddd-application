using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public Personnel ActiveVet { get; private set; }

        public Contest SetActiveVet(Personnel personnel)
        {
            this.Set(
                contest => contest.ActiveVet,
                (contest, p) => contest.ActiveVet = p,
                personnel);

            return this;
        }
    }
}
