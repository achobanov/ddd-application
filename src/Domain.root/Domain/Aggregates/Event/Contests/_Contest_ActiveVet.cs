using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
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
