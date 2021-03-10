using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Domain.Aggregates.Event.Contests;

namespace EnduranceContestManager.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<Contest>
    {
    }
}
