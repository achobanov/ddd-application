using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public partial class Event : BaseEvent<EventException>, IAggregateRoot
    {
        public Event(int id, string name, string populatedPlace)
            : base(id, name, populatedPlace)
        {
        }
    }
}
