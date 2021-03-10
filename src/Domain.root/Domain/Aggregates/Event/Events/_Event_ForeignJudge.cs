using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        [NotMapped]
        public Personnel ForeignJudge { get; private set; }

        public Event SetForeignJudge(Personnel personnel)
        {
            this.Set(
                contest => contest.ForeignJudge,
                (contest, p) => contest.ForeignJudge = p,
                personnel);

            return this;
        }
    }
}
