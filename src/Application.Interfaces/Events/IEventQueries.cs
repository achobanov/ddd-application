using EnduranceJudge.Application.Interfaces.Core;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Interfaces.Events
{
    public interface IEventQueries : IQueryRepository<Event>
    {
    }
}
