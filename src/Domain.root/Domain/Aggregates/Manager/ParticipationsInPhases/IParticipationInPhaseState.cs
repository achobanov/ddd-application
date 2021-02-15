using EnduranceContestManager.Domain.Core.Entities;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases
{
    public interface IParticipationInPhaseState : IDomainModelState
    {
        DateTime StartTime { get; }

        DateTime? ArrivalTime { get; }

        DateTime? InspectionTime { get; }

        DateTime? ReInspectionTime { get; }
    }
}
