using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel
{
    public class PersonnelException : DomainException
    {
        protected override string Entity { get; } = nameof(Personnel);
    }
}
