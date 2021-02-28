using EnduranceContestManager.Domain.Aggregates.Contest.Phases;
using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Aggregates.Manager.DTOs
{
    public class PhaseDto : IPhaseState, IPhaseForCategoryState
    {
        public int OrderBy { get; }

        public int LengthInKilometers { get; }

        public bool IsFinal { get; }

        public int MaxRecoveryTimeInMinutes { get; }

        public int RestTimeInMinutes { get; }

        public Category Category { get; }
    }
}
