using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Contracts.Events
{
    public interface IEventCommands : ICommandRepository<Event>
    {
    }
}
