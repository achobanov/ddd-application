using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Aggregates.Import.Events;

namespace EnduranceJudge.Application.Import.Contracts
{
    public interface IEventCommands : ICommandsBase<Event>
    {
    }
}
