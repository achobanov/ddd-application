using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public Personnel PresidentVetCommission { get; private set; }

        public Contest SetPresidentVetCommission(Personnel personnel)
        {
            this.Set(
                contest => contest.PresidentVetCommission,
                (contest, worker) => contest.PresidentVetCommission = worker,
                personnel);

            return this;
        }
    }
}
