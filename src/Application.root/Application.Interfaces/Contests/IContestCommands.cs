using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;

namespace EnduranceContestManager.Application.Interfaces.Contests
{
    public interface IContestCommands : ICommandRepository<ContestData>
    {
    }
}
