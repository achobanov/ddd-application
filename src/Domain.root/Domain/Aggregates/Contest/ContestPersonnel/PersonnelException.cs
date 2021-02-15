using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel
{
    public class PersonnelException : DomainException
    {
        protected override string Entity { get; } = nameof(Personnel);
    }
}
