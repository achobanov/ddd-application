using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Common
{
    public interface IEventState : IDomainModelState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }
    }
}
