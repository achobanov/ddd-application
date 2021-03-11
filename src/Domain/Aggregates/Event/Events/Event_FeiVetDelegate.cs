using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        [NotMapped]
        public Personnel FeiVetDelegate { get; private set; }

        public Event SetFeiVetDelegate(Personnel personnel)
        {
            this.Set(
                contest => contest.FeiVetDelegate,
                (contest, p) => contest.FeiVetDelegate = p,
                personnel);

            return this;
        }
    }
}
