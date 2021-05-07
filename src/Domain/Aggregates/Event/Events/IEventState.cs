using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public interface IEventState : IDomainModelState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }
    }
}
