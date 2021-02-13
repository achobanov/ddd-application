using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Domain.Models.Contests;

namespace EnduranceContestManager.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<Contest>
    {
    }
}
