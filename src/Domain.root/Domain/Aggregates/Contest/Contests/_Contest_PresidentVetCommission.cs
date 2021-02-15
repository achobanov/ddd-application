using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
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
