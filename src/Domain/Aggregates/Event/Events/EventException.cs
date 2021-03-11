using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public class EventException : DomainException
    {
        private static readonly string Name = nameof(Event);

        protected override string Entity => Name;
    }
}
