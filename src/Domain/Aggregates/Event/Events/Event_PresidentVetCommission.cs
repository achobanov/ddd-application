using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
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
