using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event : BaseEvent<EventException>, IAggregateRoot
    {
        public Event(int id, string name, string populatedPlace)
            : base(id, name, populatedPlace)
        {
        }
    }
}
