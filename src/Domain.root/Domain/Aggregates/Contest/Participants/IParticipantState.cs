using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Participants
{
    public interface IParticipantState : IDomainModelState
    {
        public string RfId { get; }
        public int ContestNumber { get; }
        int? MaxAverageSpeedInKpH { get; }
    }
}
