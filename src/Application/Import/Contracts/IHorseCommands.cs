using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Aggregates.Import.Horses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Import.Contracts
{
    public interface IHorseCommands : ICommandsBase<Horse>
    {
        Task Create(IEnumerable<Horse> domainModels, CancellationToken cancellationToken);
    }
}
