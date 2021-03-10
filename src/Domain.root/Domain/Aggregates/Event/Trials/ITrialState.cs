using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Aggregates.Event.Trials
{
    public interface ITrialState : IDomainModelState
    {
        CompetitionType Type { get; }
    }
}
