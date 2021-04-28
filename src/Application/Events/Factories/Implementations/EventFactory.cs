using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class EventFactory : IEventFactory
    {
        public Event Create(IEventState state)
        {
            var _event = new Event(default, name: state.Name, populatedPlace: state.PopulatedPlace);
            return _event;
        }
    }
}
