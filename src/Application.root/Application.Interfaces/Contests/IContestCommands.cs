using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Domain.Aggregates.Event.Events;

namespace EnduranceContestManager.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<Event>
    {
    }
}
