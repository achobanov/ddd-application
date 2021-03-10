using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        [NotMapped]
        public Personnel PresidentVetCommission { get; private set; }

        public Event SetPresidentVetCommission(Personnel personnel)
        {
            this.Set(
                contest => contest.PresidentVetCommission,
                (contest, worker) => contest.PresidentVetCommission = worker,
                personnel);

            return this;
        }
    }
}
