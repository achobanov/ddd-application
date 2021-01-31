using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Domain.Entities.Contests;

namespace EnduranceContestManager.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<Contest>
    {
    }
}
