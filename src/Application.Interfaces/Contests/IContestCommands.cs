using EnduranceJudge.Application.Interfaces.Core;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<Event>
    {
    }
}
