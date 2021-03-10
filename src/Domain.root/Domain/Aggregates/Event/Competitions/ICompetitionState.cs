using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Aggregates.Event.Competitions
{
    public interface ICompetitionState : IDomainModelState
    {
        CompetitionType Type { get; }
    }
}
