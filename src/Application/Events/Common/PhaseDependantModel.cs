using EnduranceJudge.Domain.Aggregates.Event.Phases;

namespace EnduranceJudge.Application.Events.Common
{
    public class PhaseDependantModel : IPhaseState
    {
        public int Id { get; set; }

        public int LengthInKm { get; set; }

        public bool IsFinal { get; set; }
    }
}
