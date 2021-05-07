using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents
{
    public interface IEventState : IDomainModelState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }
    }
}
