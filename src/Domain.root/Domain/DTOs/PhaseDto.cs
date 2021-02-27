using EnduranceContestManager.Domain.Aggregates.Contest.Phases;
using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.DTOs
{
    public class PhaseDto : IPhaseState, IPhaseForCategoryState
    {
        public int OrderBy { get; set; }

        public int LengthInKilometers { get; set; }

        public bool IsFinal { get; set; }

        public int MaxRecoveryTimeInMinutes { get; set; }

        public int RestTimeInMinutes { get; set; }

        public int? MaxSpeedInKpH { get; set; }

        public Category Category { get; set; }
    }
}
