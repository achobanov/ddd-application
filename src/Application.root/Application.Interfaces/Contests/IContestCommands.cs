using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Domain.Entities.Contests;

namespace EnduranceContestManager.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<Contest>
    {
    }
}
