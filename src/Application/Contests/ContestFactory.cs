using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Event.Events;

namespace EnduranceContestManager.Application.Contests
{
    public class ContestFactory : Factory<Event, IEventState>, IContestFactory
    {
        public Event Update(Event @event, string name = null, string populatedPlace = null)
            => new Event(
                @event.Id,
                name ?? @event.Name,
                populatedPlace ?? @event.PopulatedPlace);

        protected override Event FromState(IEventState state)
            => new Event(default, state.Name, state.PopulatedPlace);
    }
}
