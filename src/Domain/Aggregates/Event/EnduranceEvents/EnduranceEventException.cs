using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents
{
    public class EventException : DomainException
    {
        private static readonly string Name = nameof(Event);

        protected override string Entity => Name;
    }
}
