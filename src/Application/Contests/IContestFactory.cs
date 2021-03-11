using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Aggregates.Event.Events;

namespace EnduranceContestManager.Application.Contests
{
    public interface IContestFactory : IFactory<Event>
    {
        Event Update(Event @event, string name = null, string populatedPlace = null);
    }
}
