using EnduranceJudge.Application.Core.Factories;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Contests
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
