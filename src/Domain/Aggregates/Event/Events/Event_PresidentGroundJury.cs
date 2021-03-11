using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        [NotMapped]
        public Personnel PresidentGroundJury { get; private set; }

        public Event SetPresidentGroundJury(Personnel personnel)
        {
            this.Set(
                contest => contest.PresidentGroundJury,
                (contest, p) => contest.PresidentGroundJury = p,
                personnel);

            return this;
        }
    }
}
