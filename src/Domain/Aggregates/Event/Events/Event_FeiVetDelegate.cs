using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
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
