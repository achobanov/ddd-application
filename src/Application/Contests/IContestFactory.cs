using EnduranceJudge.Application.Core.Factories;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Contests
{
    public interface IContestFactory : IFactory<Event>
    {
        Event Update(Event @event, string name = null, string populatedPlace = null);
    }
}
