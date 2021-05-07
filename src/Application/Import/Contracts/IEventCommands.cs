using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Aggregates.Import.EnduranceEvents;

namespace EnduranceJudge.Application.Import.Contracts
{
    public interface IEventCommands : ICommandsBase<EnduranceEvent>
    {
    }
}
