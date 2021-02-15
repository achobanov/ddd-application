using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public interface IParticipationState : IDomainModelState
    {
        float AverageSpeedInKpH { get; }
    }
}
