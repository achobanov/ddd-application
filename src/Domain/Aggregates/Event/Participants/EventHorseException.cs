using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class EventHorseException : DomainException
    {
        protected override string Entity { get; } = $"Event {nameof(Horse)}";
    }
}
