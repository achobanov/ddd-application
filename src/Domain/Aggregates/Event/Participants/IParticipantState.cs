using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public interface IParticipantState : IDomainModelState
    {
        public string RfId { get; }
        public int ContestNumber { get; }
        int? MaxAverageSpeedInKpH { get; }
    }
}
