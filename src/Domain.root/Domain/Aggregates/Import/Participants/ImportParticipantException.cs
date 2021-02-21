using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Participants
{
    public class ImportParticipantException : DomainException
    {
        protected override string Entity { get; } = $"Import {nameof(Participant)}";
    }
}
