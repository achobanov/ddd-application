using EnduranceContestManager.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Manager.DTOs
{
    public class TrialDto
    {
        public DateTime StartTime { get; set; }

        public CompetitionType Type { get; set; }

        public IReadOnlyList<PhaseDto> Phases { get; set; }
    }
}
