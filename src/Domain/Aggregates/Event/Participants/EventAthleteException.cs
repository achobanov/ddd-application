using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class EventAthleteException : DomainException
    {
        protected override string Entity { get; } = $"Event {nameof(Athlete)}";
    }
}
