using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class EnduranceEventFactory : IEnduranceEventFactory
    {
        public EnduranceEvent Create(IEnduranceEventState state)
        {
            var enduranceEvent = new EnduranceEvent(state.Id, state.Name, state.PopulatedPlace);
            return enduranceEvent;
        }
    }
}
