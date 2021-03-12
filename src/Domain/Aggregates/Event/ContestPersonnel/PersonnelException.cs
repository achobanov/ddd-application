using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel
{
    public class PersonnelException : DomainException
    {
        protected override string Entity { get; } = nameof(Personnel);
    }
}
